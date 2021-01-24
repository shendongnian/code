    services.AddIdentityServer()
        .AddInMemoryClients(Config.GetClients())
        .AddInMemoryApiResources(Config.GetApis())
        .AddInMemoryIdentityResources(Config.GetIdentityResources())
        .AddConfigurationStore(options =>
        {
            options.ConfigureDbContext = builder =>
                builder.UseSqlServer(connectionString,
                    sql => sql.MigrationsAssembly(migrationsAssembly));
        })
        .AddDeveloperSigningCredential();
