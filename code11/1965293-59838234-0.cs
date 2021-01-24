    var builder = new WebHostBuilder()
                .UseContentRoot(System.IO.Directory.GetCurrentDirectory())
                .ConfigureLogging(config =>
                {
                    config.SetMinimumLevel(LogLevel.Debug);
                    config.AddConsole();
                    config.AddDebug();
                })
                .UseTestServer()
                .UseStartup<Startup>();
