    public void ConfigureServices(IServiceCollection services)
    {
        string connectionString = Configuration.GetConnectionString("ConnectionStringName");
        services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connectionString));
        ServiceProvider serviceProvider = services.BuildServiceProvider();
        AppDbContext appDbContext = serviceProvider.GetService<AppDbContext>();
        services.RegisterMyLibrary(appDbContext); // <-- Here passing the DbConext instance to the class library
        .......
    }
