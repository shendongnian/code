    public static void Main()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
         
            // create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();
         
            // entry to run app
            serviceProvider.GetService<WebJob>().RunQueue();
            serviceProvider.GetService<WebJob>().Run();
            Console.ReadLine();
        }
         
        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
              var currentDir = ProjectPath.GetApplicationRoot();
         
             // build configuration
             varconfiguration = newConfigurationBuilder()
                       .SetBasePath(currentDir)
                       .AddJsonFile("appsettings.json",false)
                       .Build();
         
             serviceCollection.AddOptions();
             serviceCollection.Configure<WebJobSettings>(configuration.GetSection("WebJobSettings"));
             // add app
             serviceCollection.AddTransient<WebJob>();
        }
    
    public class WebJob
    {
      private readonly IOptions<WebJobSettings> _webJobSettings;
      public WebJob(
        IOptions<WebJobSettings> webJobSettings)
      {
        _webJobSettings = webJobSettings;
      } 
      public void Run()
      {
             
     
     GlobalConfiguration.Configuration.UseSqlServerStorage(_webJobSettings.Value.DbConnectionString); // here is how I access the config
     
         using(var server = new BackgroundJobServer())
         {
            Console.WriteLine("Hangfire Server started. Press any key to exit...");
            Console.ReadLine();
         }
      }
    }
