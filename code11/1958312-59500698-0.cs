    // your TestContext showing constructor
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options){ }
    }
    // Then in Startup.cs
    public class Startup
    {
       public IConfiguration Configuration {get;}
       public Startup(IConfiguration configuration)
       {
          Configuration = configuration;
       }
       public void ConfigureServices(IServiceCollection services)
       {
           services.AddDbContext<TeamsDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("connection_string")));
       }
    }
