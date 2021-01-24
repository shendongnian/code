    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }
        //...
    }
