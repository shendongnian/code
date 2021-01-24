    protected void Application_Start() {
        var services = new ServiceCollection();
        ConfigureServices(services);
        //build service provider
        IServiceProvider provider = services.BuildServiceProvider();
        //Get the current resolver used by MVC
        var current = DependencyResolver.Current;
        //use that and the provider to create your custom resolver
        var resolver = new CoreDependencyResolver(provider, current);
        //now set the MVC framework to use the resolver that wraps the service provider
        //that was created from .Net Core Dependency Injection framework.
        DependencyResolver.SetResolver(resolver);
        //...
        
        AreaRegistration.RegisterAllAreas();
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
    }
    private void ConfigureServices(IServiceCollection services) {
        //... omitted for brevity (register dependencies as normal)
    }
