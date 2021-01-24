    public IConfiguration Configuration { get; }
    public Startup(IHostingEnvironment env) {
        var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
        Configuration = builder.Build();
    }
    public void ConfigureServices(IServiceCollection services) {
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        services.AddScoped<ApplicationDbContext>(_ => 
            new ApplicationDbContext(Configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IRegionService, RegionService>();
        //...
    }
    //...rest omitted for brevity
