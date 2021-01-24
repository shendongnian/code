    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }
     
        public IConfiguration Configuration { get; private set; }
     
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
     
            Configuration = builder.Build();
          Console.WriteLine(configuration.GetConnectionString("BloggingDatabase"));    
 
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
     
            ServiceProvider = serviceCollection.BuildServiceProvider();
     
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
     
        private void ConfigureServices(IServiceCollection services)
        {
            // ...
     
            services.AddTransient(typeof(MainWindow));
        }
    }
 
   
