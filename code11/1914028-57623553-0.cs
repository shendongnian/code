    services.AddTransient<IPasswordValidator<AppUser>, CustomPasswordValidator>();
    services.AddIdentity<AppUser, IdentityRole>( opts => {
       opts.Password.RequiredLength = 6;
    }).AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();
    
