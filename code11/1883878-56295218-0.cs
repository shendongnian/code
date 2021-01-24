    protected virtual void OnConfiguring(DbContextOptionsBuilder builder)
    {
        var configuration = this.Instance.GetService<IConfiguration>();
        var connectionString = configuration.GetConnectionString("<name>");
        builder.UseMySql(connectionString);
        base.OnConfiguring(builder);
    }
