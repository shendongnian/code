    public void ConfigureServices(IServiceCollection services)
    {
       //deleted extra lines for brevity 
       services.AddAuthorization(options =>
       {
          options.AddPolicy("AccessControl", policy =>
          {
               policy.RequireAuthenticatedUser();
               policy.AddRequirements(new MinimumPermissionRequirement());
          });
       });
       //injection
       services.AddScoped<IAuthorizationHandler, MinimumPermissionHandler>();
    }
