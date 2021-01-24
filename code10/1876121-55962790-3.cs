    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    
    namespace WebJob1template
    {
        class Program
        {
            static void Main()
            {
    
                var builder = new HostBuilder()
                    .UseEnvironment("Development")
                    .ConfigureAppConfiguration((context, config) => {
                        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    })
                    .ConfigureWebJobs(
                    b =>
                    {
                        b.AddAzureStorageCoreServices()
                        .AddAzureStorage()
                        .AddTimers()
                        .AddFiles();
                        //.AddDashboardLogging();
                    })
                    .ConfigureLogging((context, b) =>
                    {
                        b.SetMinimumLevel(LogLevel.Debug);
                        b.AddConsole();
                    })
                    .UseConsoleLifetime();
    
    
                var host = builder.Build();
    
                using (host)
                {
                    host.Run();
                }
            }
        }
    }
