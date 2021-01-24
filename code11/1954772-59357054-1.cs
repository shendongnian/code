    public void ConfigureServices(IServiceCollection services)
    {
      
        services.AddScoped<IYourService, YourService>();
        // Build an intermediate service provider
        var serviceProvider = services.BuildServiceProvider();
        // Resolve the services from the service provider
        var yourService = serviceProvider.GetService<IYourService>();
    }
