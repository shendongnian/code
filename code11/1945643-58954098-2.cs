    public class Startup
    {
        public IConfiguration Configuration { get; }
    
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
    
        public void ConfigureServices(IServiceCollection services)
        {
            //Map the configuration
            var connectionSection = Configuration.GetSection("ConnectionStrings");
            services.Configure<ConnectionStrings>(connectionSection );            
        }
    
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure 
        }
    }
