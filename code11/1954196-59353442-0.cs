    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddSession();
        services.AddTransient<INewsRepository, NewsRepository>();
        services.AddDbContext<BmuContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("Connectionstring")));
        services.AddMemoryCache();
    }
