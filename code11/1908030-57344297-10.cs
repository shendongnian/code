    public class DependencySetupFixture
    {
        public DependencySetupFixture()
        {
              var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", false, true));
             configuration = builder.Build();
    
             var services = new ServiceCollection();
             services = IocConfig.Configure(services, configuration)
    
             ServiceProvider = services.BuildServiceProvider();
        }
    
        public ServiceProvider ServiceProvider { get; private set; }
    }
