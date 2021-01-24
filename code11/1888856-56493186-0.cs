    public void ConfigureServices(IServiceCollection services) {
        //...
        services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(GetRedisConnectionString()));
        services.AddSingleton<IMyService>(serviceProvider => 
            new MyService(new DbContext(optionsBuilder.Options)), serviceProvider.GetRequiredService<IConnectionMultiplexer>()
        );
        //...
    }
