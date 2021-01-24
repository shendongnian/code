    public class Startup
    {   public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services){
            services.AddMvc(config => {
            var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
            config.Filters.Add(new AuthorizeFilter(policy));
           });
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles(); //this middleware also should be added to the pipeline if your template has images,css etc.
            app.UseMvcWithDefaultRoute();  
        }
    }
