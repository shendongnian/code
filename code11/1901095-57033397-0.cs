    services.AddIdentity<ApplicationUser, IdentityRole>()
           .AddRoleManager<RoleManager<IdentityRole>>()
           .AddDefaultUI()
           .AddDefaultTokenProviders()
           .AddEntityFrameworkStores<ApplicationDbContext>();
