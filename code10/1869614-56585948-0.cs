    services.Configure<CookiePolicyOptions>(options =>
            {                
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
