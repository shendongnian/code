    public static async Task Main(string[] args) {
        var host = new HostBuilder()
            .ConfigureHostConfiguration(configHost => {
                configHost.SetBasePath(GetContentRootPath());
                configHost.AddJsonFile("AppSettings.json", optional: true);
                configHost.AddCommandLine(args);
            })
            .ConfigureServices((hostContext, services) => {
                services.AddTransient<IConsumeEventBus>(....);
                services.AddHostedService<EventBusHostedService>();
            })
            .ConfigureLogging((hostContext, configLogging) => {
            })
            .UseConsoleLifetime()
            .Build();
                
        Console.WriteLine("Hello World!");
        await host.RunConsoleAsync();
    }
    
