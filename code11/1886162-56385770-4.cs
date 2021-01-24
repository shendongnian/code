    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
          .UseServiceProviderFactory(new AutofacServiceProviderFactory()) //<--NOTE THIS
          .ConfigureWebHostDefaults(webBuilder => {
              webBuilder         
                .UseStartup<Startup>()
                .ConfigureLogging((hostingContext, builder) => {
                    builder.ClearProviders();
                    builder.SetMinimumLevel(LogLevel.Trace);
                    builder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    builder.AddConsole();
                    builder.AddDebug();
                })
                .UseNLog();
        });
