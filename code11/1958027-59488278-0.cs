    public void ConfigureServices(IServiceCollection services) {
    
        //...omitted for brevity
    
        AppSettings settings = Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
        services.AddSingleton(settings);
    
        //...
    }
