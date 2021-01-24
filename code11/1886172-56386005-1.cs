    public void ConfigureServices(IServiceCollection services) {
        AppSettings appSettings = Configuration.GetSection("AppSettings").Get<AppSettings>();
        services.AddSingleton(appSettings);
        services.AddSingleton<IMyService, MyClass>();
        //. . . . 
    }
