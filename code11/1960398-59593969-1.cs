    services.AddAntiforgery(options =>
    {
        options.Cookie = new CurrentDomainCookieBuilder
        {
            // default configuration for Antiforgery cookies
            SameSite = SameSiteMode.Strict,
            HttpOnly = true,
            IsEssential = true,
            SecurePolicy = CookieSecurePolicy.None,
        };
    });
