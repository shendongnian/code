public static IWebHostBuilder CreateWebHostBuilder(string[] args) {
    // build the root 
    var configRoot = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false)
        // ...
        .Build();
    var builder = new WebHostBuilder();
    return builder
        // reuse the configRoot
        .UseConfiguration(configRoot)
        // register the configRoot as a singleton service
        .ConfigureServices(services =>{
            services.AddSingleton<IConfigurationRoot>(configRoot);
        })
        .UseStartup<Startup>()
        .ConfigureLogging(logging => {   
            //override configuration in NLog.config
            logging.ClearProviders();
            logging.SetMinimumLevel(LogLevel.Trace);
        })
        .UseKestrel();
}
