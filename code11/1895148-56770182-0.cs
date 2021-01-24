    public IConfiguration Configuration { get; }
    
    public Startup(IConfiguration configuration)
    {
    	Configuration = configuration;
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
    	services.AddDbContext<TodoContext>(options => options.UseSqlServer(Configuration.GetConnectionString("connection")));
    	...
    }
