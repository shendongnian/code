    public class Startup {
        IConfiguration Configuration;
        public Startup() {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }
    
        public void ConfigureServices(IServiceCollection services) {
            //Bind to object graph from configuration
            MyClassOptions options = Configuration.GetSection("Owner").Get<MyClassOptions>();
            //make it available to the service collection for Dependency Injection
            services.AddSingleton<MyClassOptions>(options);
            services.AddTransient<MyClass>();
    
            //...
        }
    }
