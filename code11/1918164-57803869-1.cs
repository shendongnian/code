    // Startup.cs
    public void ConfigureServices(IServiceCollection services)
    {
       ....
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ActiveUserPolicy", policyBuilder =>
                {
                    policyBuilder.RequireAuthenticatedUser();
                    policyBuilder.AddRequirements(new ActiveUserRequirement());
                });
            });
            services.AddSingleton<IAuthorizationHandler, ActiveUserRequirementHandler>();
    }
