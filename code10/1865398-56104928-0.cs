    services.AddIdentity<IdentityUser,IdentityRole>(options =>
    {
        //option settings...
    })
    .AddEntityFrameworkStores<IdentityDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();
