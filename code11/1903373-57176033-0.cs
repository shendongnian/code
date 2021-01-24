    public void ConfigureServices(IServiceCollection services)
    {
              services.Configure<PasswordHasherOptions>(options => options.CompatibilityMode = 
                PasswordHasherCompatibilityMode.IdentityV2);
    }
