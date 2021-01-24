public static IWebHostBuilder CreateWebHostBuilder(string[] args) {
    // build an instance of `IConfigurationRoot`
    var configRoot = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false)
        // ...
        .Build();
    return WebHost.CreateDefaultBuilder(args)
        // reuse the configuration
        .UseConfiguration(configRoot)
        // register the configRoot as a singleton
        .ConfigureServices(services =>{
            services.AddSingleton<IConfigurationRoot>(configRoot);
        })
        .UseStartup<Startup>()
        .ConfigureLogging(logging => {   
            //override configuration in NLog.config
            logging.ClearProviders();
            logging.SetMinimumLevel(LogLevel.Trace);
        });
}
