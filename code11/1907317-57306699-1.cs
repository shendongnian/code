     services.AddIdentity<AppUser, IdentityRole<string>>(options =>
                 {
                     options.Password.RequireDigit = false;
                     options.Password.RequiredLength = 4;
                     options.Password.RequireLowercase = false;
                     options.Password.RequireNonAlphanumeric = false;
                     options.Password.RequireUppercase = false;
    
                     options.User.RequireUniqueEmail = true;
    
                 })
                    .AddRoles<IdentityRole<string>>()
                    .AddEntityFrameworkStores<AppIdentityDbContext>()
                    .AddRoleManager<RoleManager<IdentityRole<string>>>()
                    .AddDefaultTokenProviders();
               
