    builderModel.Services.AddDbContext<DB1Context>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DB1Context")));
    
    builderModel.Services.AddDbContext<DB2Context>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DB2Context")));
