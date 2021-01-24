    services.AddTransient<IAuthorizationHandler, SetTenantIdentityHandler>();
    
    // Although this isn't used to generate the identity, it is needed
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Audience = "https://localhost:5000/";
        options.Authority = "https://localhost:5000/identity/";
    });
    
    services.AddAuthorization(authConfig =>
    {
        authConfig.AddPolicy(Policies.HasRoleInTenant, policyBuilder => {
            policyBuilder.RequireAuthenticatedUser();
            policyBuilder.AddRequirements(new TenantRoleRequirement());
        });
    });
