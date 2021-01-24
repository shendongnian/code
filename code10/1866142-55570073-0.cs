    using Microsoft.ApplicationInsights.Channel;
    using Microsoft.ApplicationInsights.Extensibility;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;
    
    namespace ConsoleApp3netcore
    {
        class Program
        {
            private readonly ILogger logger;
            static InMemoryChannel channel = new InMemoryChannel();
    
            static async Task Main(string[] args)
            {
                ServiceProvider serviceProvider = ConfigureServices();
    
                var program = serviceProvider.GetService<Program>();
                await program.Run();
            }
    
            public Program(ILogger<Program> logger)
            {
                this.logger = logger;
            }
    
            private static ServiceProvider ConfigureServices()
            {
                var services = new ServiceCollection();
                services.Configure<TelemetryConfiguration>(
                    (config) =>
                    {
                        config.TelemetryChannel = channel;
                    }
                );
                services
                    .AddLogging(opt =>
                    {
                        opt.AddConsole();
                        opt.AddApplicationInsights();
                    })
                    .AddTransient<Program>();
                return services.BuildServiceProvider();
            }
    
            public async Task Run()
            {
                try
                {
                    throw new Exception("my exception 111");
                }
                catch (Exception e)
                {
                    logger.LogError(e, "Exception occured");
                    // How to flush Application insights here
                    channel.Flush();
    
                    await Task.Delay(1000);
                    throw;
                }
            }
        }
    }
