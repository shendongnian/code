    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSignalR();
        services.AddScoped<ModuleLoader>();
    } 
