    using Microsoft.Extensions.Configuration;
    
    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                    WebHost.CreateDefaultBuilder(args)
                        .ConfigureAppConfiguration((hostingContext, config) =>
                        {
                            config.AddEnvironmentVariables();
                        })
                        .UseStartup<Startup>();
