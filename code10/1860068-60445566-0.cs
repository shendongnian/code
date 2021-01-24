        services.Configure<CookiePolicyOptions>(options =>
                        {
                            // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                            options.CheckConsentNeeded = Context => false;
                            options.MinimumSameSitePolicy = SameSiteMode.None;
                        });
            
    services.AddMemoryCache();
                        services.AddSession(options => {
                            // Set a short timeout for easy testing.
                            options.IdleTimeout = TimeSpan.FromMinutes(10);
                            options.Cookie.HttpOnly = true;
                            // Make the session cookie essential
                            options.Cookie.IsEssential = true;
                        });
