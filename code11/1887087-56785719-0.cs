        public class Program
        {
            public static async Task Main(string[] args)
            {
                var param = Console.ReadLine();
                var host = new HostBuilder()
                    .ConfigureHostConfiguration(configHost =>
                    {
                        configHost.SetBasePath(Directory.GetCurrentDirectory());
                        configHost.AddJsonFile("hostsettings.json", optional: true);
                        configHost.AddEnvironmentVariables(prefix: "PREFIX_");
                        configHost.AddCommandLine(args);
                    })
                    .ConfigureAppConfiguration((hostContext, configApp) =>
                    {
                        configApp.AddJsonFile("appsettings.json", optional: true);
                        configApp.AddJsonFile(
                            $"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", 
                            optional: true);
                        configApp.AddEnvironmentVariables(prefix: "PREFIX_");
                        configApp.AddCommandLine(args);
                    })
                    .ConfigureServices((hostContext, services) =>
                    {
                        services.AddSingleton(new CommandLineArgs { Args = param });
                        services.AddHostedService<LifetimeEventsHostedService>();
                        services.AddHostedService<TimedHostedService>();
                    })
                    .ConfigureLogging((hostContext, configLogging) =>
                    {
                        configLogging.AddConsole();
                        configLogging.AddDebug();
                    })
                    .UseConsoleLifetime()
                    .Build();
                await host.RunAsync();
            }
        }
