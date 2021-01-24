    public class Program
        {
            public static void Main(string[] args)
            {
                var serviceCollection = new ServiceCollection();
                ConfigureServices(serviceCollection);
                var serviceProvider = serviceCollection.BuildServiceProvider();
    
                var app = serviceProvider.GetService<Application>();
                Task.Run(() => app.Run()).Wait();
            }
    
            private static void ConfigureServices(IServiceCollection services)
            {
                // Add Logger
                services.AddLogging(configure =>
                {
                    configure.AddConsole();
                })
                    .AddTransient<Application>();
    
                // Register Application
                //services.AddTransient<Application>();
            }
        }
    
        public class Application
        {
            private readonly ILogger<Application> logger;
    
            public Application(ILogger<Application> logger)
            {
                this.logger = logger;
                this.logger.LogInformation("In Application::ctor");
            }
    
            public async Task Run()
            {
                logger.LogInformation("Info: In Application::Run");
                logger.LogWarning("Warn: In Application::Run");
                logger.LogError("Error: In Application::Run");
                logger.LogCritical("Critical: In Application::Run");
            }
    
            //public void Run()
            //{
            //    logger.LogInformation("Info: In Application::Run");
            //    logger.LogWarning("Warn: In Application::Run");
            //    logger.LogError("Error: In Application::Run");
            //    logger.LogCritical("Critical: In Application::Run");
            //}
        }
