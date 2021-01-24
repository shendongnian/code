public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureLogging((hostingContext, logging) =>
            {
                logging.ClearProviders();
                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                logging.AddDebug();
                logging.AddConsole();
            })
            .ConfigureWebHostDefaults(webBuilder => webBuilder
                .UseStartup<Startup>()
                .UseNLog());
    
You may need to reference additional nuget packages in order to use some of the logging extension methods:
Microsoft.Extensions.Logging
Microsoft.Extensions.Logging.Console
Microsoft.Extensions.Logging.Debug
Once we put the above fix in place, we stopped seeing EventSource logging issues.
