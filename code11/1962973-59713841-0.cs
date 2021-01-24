    public void ConfigureServices(IServiceCollection services)
    {
        // ...
        services.AddTransient<RequestCultureMiddleware>();
    }
