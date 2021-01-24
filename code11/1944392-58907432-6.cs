    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) => {
                services.AddHttpClient();
                services.AddSingleton<ILoggerProvider, SlackLoggerProvider>();
            });
