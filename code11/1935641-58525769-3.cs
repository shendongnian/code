            public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                    .UseStartup<ProjenInlineApiStartup>()
                    .UseKestrel()
                    .UseContentRoot(PathDomain)//<------THIS IS THE LINE
                    .ConfigureAppConfiguration((hostingContext, config) =>
                    {
    
                        string CONFIG_SERVER_FILE = Environment.GetEnvironmentVariable("CONFIG_SERVER_FILE");
                        string RUN_PLATFORM = Environment.GetEnvironmentVariable("RUN_PLATFORM");
                        string ASPNETCORE_ENVIRONMENT = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                        Console.WriteLine("ASPNETCORE_ENVIRONMENT: " + ASPNETCORE_ENVIRONMENT);
                        Console.WriteLine("CONFIG_SERVER_FILE: "+ CONFIG_SERVER_FILE);
                        Console.WriteLine("RUN_PLATFORM: " + RUN_PLATFORM);
    
                        config.AddJsonFile("appsettings.json", true, true)
                        .AddJsonFile($"appsettings.{RUN_PLATFORM}.json", true, true);
                        
                        config.AddEnvironmentVariables();
    
                        if (args != null)
                        {
                            config.AddCommandLine(args);
                        }
                    })
                    .ConfigureLogging((hostingContext, config) => { config.ClearProviders(); });
