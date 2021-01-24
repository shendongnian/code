    services.AddDbContext<DBContext>(opts => opts.UseOracle(RegistryReader.GetRegistryValue(RegHive.HKEY_LOCAL_MACHINE, Configuration["AppSettings:RegPath"], "DB.ConnectionString", RegWindowsBit.Win64)));
    services.AddTransient<ILogging<ServiceLog>, ServiceLogRepo>();
    services.AddSingleton<IMemoryCache, MemoryCache>();    
    services.AddHttpClient<IWSConfig, WSConfig>();
    services.AddHttpClient<IWSLoadLeave, WSLoadLeave>();
    services.AddHttpClient<IWSLoadPartics, WSLoadPartics>();
    services.AddScoped<ITerm, Term>();
    services.AddScoped<IPerson, Person>();
