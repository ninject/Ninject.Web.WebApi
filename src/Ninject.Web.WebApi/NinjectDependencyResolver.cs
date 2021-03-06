// -------------------------------------------------------------------------------------------------
// <copyright file="NinjectDependencyResolver.cs" company="Ninject Project Contributors">
//   Copyright (c) 2007-2010 Enkari, Ltd. All rights reserved.
//   Copyright (c) 2010-2017 Ninject Project Contributors. All rights reserved.
//
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
//   You may not use this file except in compliance with one of the Licenses.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//   or
//       http://www.microsoft.com/opensource/licenses.mspx
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Ninject.Web.WebApi
{
    using System.Runtime.Remoting.Messaging;
    using System.Web.Http.Dependencies;

    /// <summary>
    /// Dependency resolver implementation for ninject.
    /// </summary>
    public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
    {
        /// <summary>
        /// The Ninject Owin request scope.
        /// </summary>
        public const string NinjectWebApiRequestScope = "NinjectWebApiRequestScope";

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectDependencyResolver"/> class.
        /// </summary>
        /// <param name="kernel">The <see cref="IKernel"/>.</param>
        public NinjectDependencyResolver(IKernel kernel)
            : base(kernel)
        {
        }

        /// <summary>
        /// Begins the scope.
        /// </summary>
        /// <returns>The new scope.</returns>
        public virtual IDependencyScope BeginScope()
        {
            var scope = new NinjectDependencyResolver(this.Kernel);
            CallContext.LogicalSetData(NinjectWebApiRequestScope, scope);

            return scope;
        }
    }
}