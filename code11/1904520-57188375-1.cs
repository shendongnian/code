    services.AddDbContextPool<dbContext>(options => options
        .UseMySql(Configuration.GetConnectionString("MySQLConnection"), mysqlOptions =>
        {
            mysqlOptions.ServerVersion(new Version(5, 7, 14), ServerType.MySql);
        })
        .UseLazyLoadingProxies()
    );
