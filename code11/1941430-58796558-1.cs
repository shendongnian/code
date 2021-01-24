        public class Startup
        {
            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }
            public IConfiguration Configuration { get; }
            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddMvc(options => {
                    options.EnableEndpointRouting = false;
                });
                services.AddApiVersioning();
                services.AddSingleton<IConfigureOptions<ApiVersioningOptions>, ConfigureApiVersioningOptions>();
            }
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                app.UseMvc();
            }
        }
