    //...
    var services = new ServiceCollection()
        .AddSingleton(provider => (IConfigurationRoot)config)
        .AddDbContext<Context>(options => options.UseNpgsql(config.GetConnectionString("DefaultConnection")))
        .AddScoped<IQueryService, QueryService>()
        .AddScoped<MockDataServer>() //<-- Add server
        .BuildServiceProvider();
    MockDataServer server = services.GetService<MockDataServer>();
    server.ReadData();
