    public override void ConfigureDb(IServiceCollection services)
    {
        var dbName = Guid.NewGuid().ToString();
        services.AddDbContext<CarContext>(options => options.UseInMemoryDatabase(dbName));
        services.AddTransient<DbSeeder>();
    }  
