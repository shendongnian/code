    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    namespace ConsoleApp
    {
        class Program
        {
            public static void Main(string[] args)
            {
                CreateHostBuilder(args).UseWindowsService().Build().Run();
            }
    
            private static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureServices((hostContext, services) =>
                    {
                        services.AddHostedService<Worker>();
                    });
        }
    }
