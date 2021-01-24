    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        services.AddScoped<IDispatcher, Dispatcher>();
        services.AddScoped<IQueryDispatcher, QueryDispatcher>();
    }
