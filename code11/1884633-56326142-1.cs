    using Microsoft.Extensions.Logging; //Had to write manually
    public static void Main(string[] args)
            {
                var logRepo = LogManager.GetRepository(Assembly.GetEntryAssembly());
                log4net.Config.XmlConfigurator.Configure(logRepo, new FileInfo("log4net.config"));
    
                CreateWebHostBuilder(args).Build().Run();
            }
    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureLogging((webHostBuilderContext, loggingBuilder) =>
            {
                loggingBuilder.AddLog4Net();
            })
                .UseStartup<Startup>();
    }
