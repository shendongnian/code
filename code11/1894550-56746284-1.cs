        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
      
        public void ConfigureServices(IServiceCollection services)
        {
           ...
           // Configure Options using Microsoft.Extensions.Options.ConfigurationExtensions
            services.Configure<YourSettings>(Configuration.GetSection(nameof(YourSettings))); // for your specific example just pass in the string "Directories" since you don't have a section called "YourSettings" - obviously just update the class to encompass whatever settings you want it to
            services.AddSingleton(Configuration); //for DI
           ...
        }
