    services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme,
                opt =>
                {
                    opt.AccessDeniedPath = $"/Home/AccessDeniedCustom";
                });
    
     services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder().
                RequireAuthenticatedUser().
                RequireRole("AuthenticatedUser").
                RequireRole("Your2ndRole").
                    Build();
                options.Filters.Add(new AuthorizeFilter(policy));
                options.Filters.Add(new RequireHttpsAttribute());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
