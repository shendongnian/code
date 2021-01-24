    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<MyFirstConfig>(Configuration.GetSection("Next"));
        services.Configure<MySecondConfig>(Configuration.GetSection("CustomGateway"));
        
        services.AddSingleton<IFirstService, MyFirstService>();
        services.AddSingleton<ISecondService, MySecondService>();
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        app.ApplicationServices.GetRequiredService<IFirstService>().StartFeed();
    }
