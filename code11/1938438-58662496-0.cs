    public class Program
    {
        public static void Main(string[] args)
        {
           IHostBuilder hostBuilder = CreateHostBuilder(args);
           IHost host = hostBuilder.Build();
           host.Run();
        }
    
        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(options =>
                    {
                        options.ListenLocalhost(5001, o => o.Protocols =
                            HttpProtocols.Http2);
    
                        // ADDED THIS LINE to fix the problem
                        options.ListenLocalhost(11837, o => o.Protocols =
                            HttpProtocols.Http1);
                    });
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
