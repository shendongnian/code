    public void ConfigureAuth(IAppBuilder app)
    {
        var expiryDate = DateTime.Now.Date.AddDays(1).AddHours(4);
        var ts = expiryDate - DateTime.Now;
        app.UseCookieAuthentication(new CookieAuthenticationOptions
        {
            AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            ExpireTimeSpan = TimeSpan.FromHours(ts.Hours),
            LoginPath = new PathString("/Account/Login"),
            Provider = new CookieAuthenticationProvider
            {
                OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<UserManager, ApplicationUser>(
                    validateInterval: TimeSpan.FromMinutes(30),
                    regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
            }
        });
    }
