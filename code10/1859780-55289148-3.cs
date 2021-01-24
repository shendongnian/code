            services.AddMemoryCache(options => 
            {
                // options.SizeLimit = 4096;
                options.ExpirationScanFrequency = TimeSpan.FromMinutes(20);
            });
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
