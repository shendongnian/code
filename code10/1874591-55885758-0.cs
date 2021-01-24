    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<OracleDbContext>(builder => builder.UseSqlServer(connectionString));
        services.AddDbContext<AppsDbContext>(builder => builder.UseSqlServer(connectionString));
    }
