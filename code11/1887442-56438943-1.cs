     public class Startup
    {
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {
      
        // Start Registering and Initializing AutoMapper
        Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperConfig>());
        services.AddAutoMapper();
       
    }
     }
