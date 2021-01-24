    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
          .ConfigureWebHostDefaults(webBuilder => {
              webBuilder
                .ConfigureServices(services => services.AddAutofac()) //<--NOTE THIS
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
