    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Hosting;
    namespace ConsoleApp20
    {
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new HostBuilder();
            builder.ConfigureWebJobs(b =>
            {
                b.AddAzureStorageCoreServices();
                b.AddTimers();
            });
            builder.ConfigureLogging((context, b) =>
            {
                b.AddConsole();
                
            });
            var host = builder.Build();
            using (host)
            {
                host.Run();
            }
        }
    }
    }
