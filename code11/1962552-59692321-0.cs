        services.AddDbContextPool<GooddbContext>(
            options => options.UseSqlServer(Configuration.GetConnectionString("EmployeeDBConnection")));
        services.AddDALDependenciesLibraries();
        services.AddControllersWithViews();
    }
