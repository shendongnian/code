                public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                    WebHost.CreateDefaultBuilder(args)
                        .UseStartup<Startup>()
                        .ConfigureLogging(config => {
                            config.ClearProviders();
                            config.AddProvider(new CustomLoggerProvider());
                        });
