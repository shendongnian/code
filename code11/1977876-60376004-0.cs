    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    
        public IConfiguration Configuration { get; }
    
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    
            // other services configuration here
    
            // IMPORTANT: This should be the last line of ConfigureServices!
            IOC.CurrentProvider = services.BuildServiceProvider();
        }
    ...
