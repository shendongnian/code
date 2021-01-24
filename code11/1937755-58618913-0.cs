    public void ConfigureServices(IServiceCollection services)
    {
        string connection = Configuration.GetConnectionString("ConnectionDB");
        services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(connection), ServiceLifetime.Transient, ServiceLifetime.Singleton);
    
        services.AddSingleton<Project>();
    }
