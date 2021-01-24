    services.AddDbContext<EFCoreDemoContext>(options =>
    {
    	options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                assembly => assembly.MigrationsAssembly(typeof(EFCoreDemoContext).Assembly.FullName));
    });
