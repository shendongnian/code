csharp
namespace Microsoft.Azure.Management.AppService.Fluent.HostNameBinding.Definition
{
    using Microsoft.Azure.Management.AppService.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    /// <summary>
    /// The stage of a hostname binding definition allowing domain to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithDomain<ParentT> 
    {
        /// <summary>
        /// Binds to a 3rd party domain.
        /// </summary>
        /// <param name="domain">The 3rd party domain name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.HostNameBinding.Definition.IWithSubDomain<ParentT> WithThirdPartyDomain(string domain);
        /// <summary>
        /// Binds to a domain purchased from Azure.
        /// </summary>
        /// <param name="domain">The domain purchased from Azure.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.HostNameBinding.Definition.IWithSubDomain<ParentT> WithAzureManagedDomain(IAppServiceDomain domain);
    }
    /// <summary>
    /// The stage of a hostname binding definition allowing sub-domain to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithSubDomain<ParentT> 
    {
        /// <summary>
        /// Specifies the sub-domain to bind to.
        /// </summary>
        /// <param name="subDomain">The sub-domain name excluding the top level domain, e.g., "www".</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.HostNameBinding.Definition.IWithHostNameDnsRecordType<ParentT> WithSubDomain(string subDomain);
    }
  [1]: https://www.nuget.org/packages/Microsoft.Azure.Management.AppService.Fluent/
