    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Logging;
    using System.IO;
    using System.Reflection;
    
    namespace TryLog4net
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                CreateWebHostBuilder(args).Build().Run();
            }
    
            public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((hostingContext, logging) =>
                {
                    var assembly = Assembly.GetAssembly(typeof(Program));
                    var pathToConfig = Path.Combine(hostingContext.HostingEnvironment.ContentRootPath, "log4net.config");
                     var logManager = new AppLogManager(pathToConfig, assembly);
    
                    logging.AddLog4Net(new Log4NetProviderOptions
                    {
                        ExternalConfigurationSetup = true
                    });
                })
                .UseStartup<Startup>();
        }
    }
