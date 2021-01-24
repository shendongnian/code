        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));
        services.AddDefaultIdentity<AppUser>()
        .AddEntityFrameworkStores<DataContext>();
