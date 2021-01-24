    using System;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var builder = new HostBuilder();
                builder.ConfigureWebJobs(b =>
                {
                    b.AddAzureStorage();
                    b.AddAzureStorageCoreServices();
                });
                builder.ConfigureLogging((context, b) =>
                {
                    b.AddConsole();
                });
    
                builder.ConfigureWebJobs(b =>
                {
                    b.AddAzureStorageCoreServices();
                    b.AddAzureStorage();
                });
    
                var host = builder.Build();
                using (host)
                {
                    host.Run();
                }
            }
        }
    }
