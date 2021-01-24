            public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseApplicationInsights()  // add this line of code, and it will auto-read ikey from appsettings.json.
            .UseStartup<Startup>()
            .ConfigureLogging(logging =>
            {
                //then you can remove instrumentation key from here.
                logging.AddApplicationInsights();
                logging.AddFilter<ApplicationInsightsLoggerProvider>("", LogLevel.Trace);
    
                
                logging.AddFilter<ApplicationInsightsLoggerProvider>("Microsoft", LogLevel.Warning);
            }).Build();
