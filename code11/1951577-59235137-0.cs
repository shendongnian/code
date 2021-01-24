    public class TestStartup : IStartup {
        private readonly string settings;
        public TestStartup(string settings) {
            this.settings = settings;
        }
        public IServiceProvider ConfigureServices(IServiceCollection services) {
           var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile(settings, false) //<--just an example
               .AddEnvironmentVariables()
               .Build();
            services.AddMvc()
                .SetCompatibilityVersion(version: CompatibilityVersion.Version_2_2);
            //...Code to add required services based on configuration
            return services.BuildServiceProvider();
        }
    
        public void Configure(IApplicationBuilder app) {
            app.UseMvc();
            //...Code to configure test Startup
        }
    }
    
