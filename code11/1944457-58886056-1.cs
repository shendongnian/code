    public class Startup : ServiceStartup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        ///     This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            var yourConfiguration = new YourOwnConfigurationClass();
            _configuration.Bind(nameof(YourOwnConfigurationClass), yourConfiguration );
            services.AddSingleton(yourConfiguration )
        }
    } 
