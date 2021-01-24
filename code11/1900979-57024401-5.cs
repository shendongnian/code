    public void ConfigureServices(IServiceCollection services)
    {
        string connection = //correct connection string used in Scaffolding
        services.AddDbContext<Models.WebsiteContext>(options => options.UseSqlServer(connection));
        services.AddSingleton<IMyInterface, MyService>();
        services.AddMvc()
    }
