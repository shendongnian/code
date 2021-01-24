    public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
    
    
    
                services.AddMvc((options)=> {
    
                    options.Conventions.Add(new ApplicationDescription());
                    options.Conventions.Add(new ControllerDescriptionAttribute("aa"));
    
                }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            }
    
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            { 
            }
        }
