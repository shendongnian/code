    var host = new HostBuilder()        .
        .ConfigureServices(ConfigureServices)
        .UseConsoleLifetime()
        .Build();
    
    await host.RunAsync();
    private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services
            .AddTransient<IThing, Thingy>()
            .AddTransient<Stuff>()
            .AddHostedService<MyService>();
    }
