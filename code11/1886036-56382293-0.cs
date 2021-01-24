    public static IWebHostBuilder CreateWebHostBuilder(String[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging((context, logging) =>
                {
                    var instrumentationKey = context.Configuration.GetSection("ApplicationInsights:InstrumentationKey").Value;
                    if (String.IsNullOrWhiteSpace(instrumentationKey))
                    {
                        return;
                    }
                    // When not in development, remove other loggers like console, debug, event source etc.
                    // and only use ApplicationInsights logging
                    if (!context.HostingEnvironment.IsDevelopment())
                    {
                        logging.ClearProviders();
                    }
                    logging.AddApplicationInsights(instrumentationKey);
                });
