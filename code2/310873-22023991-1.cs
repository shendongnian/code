    var factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
 
    var proxyTypesProvider = factory as IProxyTypesAssemblyProvider;
    if (proxyTypesProvider != null)
    {
        proxyTypesProvider.ProxyTypesAssembly = typeof(Xrm.XrmServiceContext).Assembly;
    }
    // Use the factory to generate the Organization Service.
    var service = factory.CreateOrganizationService(context.UserId);
