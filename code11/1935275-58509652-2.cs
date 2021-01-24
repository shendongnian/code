    services.AddDbContext<Context>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
    
    services.AddScoped<Query>();
    services.AddScoped<Schema>();
    
    services.AddGraphQL()
        .AddGraphTypes(ServiceLifetime.Scoped);;
