    private Settings _settings;
    public Startup(IConfiguration configuration, ...)
    {
        Configuration = configuration;
        ...
    }
    
    public IConfiguration Configuration { get; }
    ...
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddOptions()
            .Configure<Settings>(Configuration.GetSection("Settings"))
            .AddSingleton(Configuration);
        _settings = Configuration.GetSection(nameof(Settings)).Get<Settings>();
    
        services.AddTransient<DesignTimeDbContextFactory>();
    
        services.AddDbContext<MyContext>(options =>
        {
            if (_settings.DatabaseSettings.UseInMemory)
            {
                options.UseInMemoryDatabase("DummyInMemoryDatabase");
            }
            else
            {
                // Option 1
                options.UseSqlServer(_settings.DatabaseSettings.BuildConnectionString());
                // Option 2
                options.UseSqlServer(_settings.ConnectionStrings.MyConnection);
            }
        });
        ...
    }
