    public class Startup {
    
        public void ConfigureServices(IServiceCollection services) {
            services.AddHostedService<HostedService>();
        }
    
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            //...
        }
    }
