    public class IntegrationStartup : Startup
        {
            public IntegrationStartup(IConfiguration configuration) : base(configuration)
            {
                Configuration = configuration;
            }
    
            public IConfiguration Configuration { get; }
    
            // This method gets called by the runtime. Use this method to add services to the container.
            public override void ConfigureServices(IServiceCollection services)
            {
                services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
    
                services.AddDbContext<StreetJobContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryAppDb");
                });
    
                //services.InjectServices();
                //here you can set your ICartRepository DI configuration
    
    
                services.AddMvc(option => option.EnableEndpointRouting = false)
                    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                    .AddApplicationPart(Assembly.Load(new AssemblyName("StreetJob.WebApp")));
    
                ConfigureAuthentication(services);
            }
    
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
                using (var serviceScope = serviceScopeFactory.CreateScope())
                {
                    //Here you can add some data configuration
                }
    
                app.UseMvc();
            }
