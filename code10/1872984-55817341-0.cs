    private static void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IMyServiceDataAccess, MyServiceDataAccess>();
        serviceCollection.AddSingleton<MyService>();
    }
