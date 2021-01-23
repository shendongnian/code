    var context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
    var factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
    var tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
    var proxyTypesProvider = factory as IProxyTypesAssemblyProvider;
    if (proxyTypesProvider != null)
    {
        proxyTypesProvider.ProxyTypesAssembly = typeof(Xrm.XrmServiceContext).Assembly;
    }
    // Use the factory to generate the Organization Service.
    var service = factory.CreateOrganizationService(context.UserId);
