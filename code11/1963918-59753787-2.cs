    public void ConfigureServices(IServiceCollection services)
    {
        string connectionString = Configuration.GetConnectionString("ConnectionStringName");
        services.AddDbContext<DemoDbContext>(option => option.UseSqlServer(connectionString));
        ServiceProvider serviceProvider = services.BuildServiceProvider();
        DemoDbContext demoDbContext = serviceProvider.GetService<DemoDbContext>();
        services.RegisterMyLibrary(demoDbContext); // <-- Here passing the DbConext instance to the class library
        .......
    }
