    public static void Main()
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
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
