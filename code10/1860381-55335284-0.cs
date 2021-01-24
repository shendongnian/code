    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            CurrentEnvironment = env;
        }
        public IConfiguration Configuration { get; }
        public IHostingEnvironment CurrentEnvironment { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddProblemDetails(setup=> {
              
                setup.IncludeExceptionDetails = _ => CurrentEnvironment.IsDevelopment();
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
        public void Configure(IApplicationBuilder app)
        {           
            app.UseProblemDetails();           
            //...
        }
    }
