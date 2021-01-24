    private static IHost BuildEngineHost(string[] args)
    {
        var engineBuilder = new HostBuilder()
            .ConfigureHostConfiguration(config =>
            {
                config.AddEnvironmentVariables();
                config.AddCommandLine(args);
            })
            .ConfigureAppConfiguration((hostContext, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                config.AddEnvironmentVariables();
                if(hostContext.HostingEnvironment.IsDevelopment())
                    config.AddUserSecrets<EngineOptions>();
            })
            .ConfigureServices((hostContext, services) =>
            {
                services.Configure<EngineOptions>(hostContext.Configuration.GetSection("EngineOptions"));
                services.AddHostedService<EtlEngineService>();
            })
            .ConfigureLogging((hostContext, logging) =>
            {
                logging.AddConfiguration(hostContext.Configuration.GetSection("Logging"));
                logging.AddConsole();
            });
        return engineBuilder.Build();
    }
