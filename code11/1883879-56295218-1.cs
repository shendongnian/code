    protected virtual void OnConfiguring(DbContextOptionsBuilder builder)
    {
        var configuration = (this as IInfrastructure<IServiceProvider>).GetService<IConfiguration>();
        var connectionString = configuration.GetConnectionString("<name>");
        builder.UseMySql(connectionString);
        base.OnConfiguring(builder);
    }
