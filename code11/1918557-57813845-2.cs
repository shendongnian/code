    services.AddDbContext<CommoditiesContext>(
        options => options.UseSqlServer(
          Configuration.GetConnectionString("CommoditiesContext")
        )
    );
    services.AddDbContext<AnotherDbContext>(
        options => options.UseSqlServer(
          Configuration.GetConnectionString("AnotherDbContext")
        )
    );
