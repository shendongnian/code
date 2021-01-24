        public class Startup
    {
        // Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ...
    Mapper.Reset(); // Useful if you're using code-first and migrations.
    services.AddAutomapper();
        }
    
        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            ...
        }
    }
