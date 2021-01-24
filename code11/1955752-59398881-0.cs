    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Serilog;
    
    namespace WorkerService1
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                CreateHostBuilder(args).Build().Run();
            }
    
            public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureServices((hostContext, services) =>
                    {
                        services.AddHostedService<Worker>();
                    })
                    .UseSerilog(new LoggerConfiguration()
                        .WriteTo.Console()
                        .WriteTo.File("logs\\log.txt", rollingInterval: RollingInterval.Day)
                        .CreateLogger(), false);
        }
    }
