    public class Startup {
        IConfiguration Configuration;
        public Startup() {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }
    
        public void ConfigureServices(IServiceCollection services) {
    
            MyClassOptions options = Configuration.Get<MyClassOptions>();
            services.AddSingleton<MyClassOptions>();
            services.AddTransient<MyClass>();
    
            //...
        }
    }
