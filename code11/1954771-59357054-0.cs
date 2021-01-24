    public void ConfigureServices(IServiceCollection services)
    {
       
    
        services.AddHttpContextAccessor();
        // Build an intermediate service provider
        var serviceProvider = services.BuildServiceProvider();
        // Resolve the services from the service provider
        var httpContextAccessor = serviceProvider.GetService<IHttpContextAccessor>();
    }
