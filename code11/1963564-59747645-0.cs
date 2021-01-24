c#
services.Configure<CookiePolicyOptions>(options =>
            {
                options.ConsentCookie.IsEssential = true;
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
c#
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                   .AddCookie(options =>
                   {
                       options.Cookie.IsEssential = true;
                       options.Cookie.HttpOnly = true;
                       options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                       options.Cookie.SameSite = SameSiteMode.None;
                       options.Cookie.Name = "Cookie";
                       options.LoginPath = "/Discord/Signin/Redirect";
                       options.LogoutPath = "/Discord/Signout";
                   });
the `options.ConsentCookie.IsEssential = true;` ignored GDRP and allows cookies to be set in the browser
