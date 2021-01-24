    var services = new ServiceCollection()
        .AddLogging(b => b.AddConsole())
        .AddDbContext<UnderstandingDIContext>(options =>
            options.UseSqlite(builder.GetConnectionString("DefaultConnection")));
    // register `Worker` in the service collection
    services.AddTransient<Worker>();
    // build the service provider
    var serviceProvider = services.BuildServiceProvider();
    // resolve a `Worker` from the service provider
    var worker = serviceProvider.GetService<Worker>();
    var logger = serviceProvider.GetService<ILogger<Program>>();
    logger.LogInformation("Starting Application");
    worker.Run();
    logger.LogInformation("Closing Application");
