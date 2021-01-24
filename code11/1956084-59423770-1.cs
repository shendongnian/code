         public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging(loggingBuilder =>
                {
                    loggingBuilder.AddConsoleAdvanced(new ConsoleLoggerSettings()
                    {
                        IncludeLineBreak = false,
                        IncludeTimestamp = true,
                        IncludeZeroEventId = false,
                        IncludeLogNamespace = false
                    });
                    
                })
                .UseStartup<Startup>();
