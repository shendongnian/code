    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseConsoleLifetime()
            .ConfigureServices((hostContext, services) => {
                services
                    .AddOptions()
                    .Configure<mailsettings>(hostContext.Configuration.GetSection("mailsettings"))
                    .AddHostedService<Worker>();
            });
