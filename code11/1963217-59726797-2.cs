    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .ConfigureLogging(builder =>
            {
                var sp = builder.Services.BuildServiceProvider();
                builder.AddProvider(new SignalrRLoggerProvider(sp));
            });
