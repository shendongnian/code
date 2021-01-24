     public class Startup
         { 
                public Startup(IHostingEnvironment env , IConfiguration configuration)
                {
                    Configuration = configuration;
                  
                }
        
                public IConfiguration Configuration { get; }
        
              
                public void ConfigureServices(IServiceCollection services)
                {
                    services.AddSingleton<IConfiguration>(provider => configuration);
                    services.AddSingleton<AppSettingUtil>();
                }
          }
