    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config) 
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the 
        container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MainContext>(options => 
               options.UseOracle(_config["CONNECTION_STRING"]));
        }
     }
