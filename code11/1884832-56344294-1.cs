    services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.TokenValidationParameters = GetTokenValidationParameters();
    })
    .AddJwtBearer("newSchema", options =>
    {
        options.TokenValidationParameters = GetNewSchemaTokenValidationParameters();
    });
    services.AddAuthorization(options =>
    {
        options.DefaultPolicy = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .AddAuthenticationSchemes("newSchema") //add new schemas here
            .Build();
    
        //here: add static policies as much as you want   
        options.AddPolicy("newpolicy", new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .AddAuthenticationSchemes("newSchema")
            .AddRequirements(new MyNewAuthorizationRequirement("newpolicy"))
            .Build());
    
    });
    services.AddSingleton<IAuthorizationHandler, MyAuthorizationHandler>();
    services.AddSingleton<IAuthorizationHandler, MyNewAuthorizationHandler>();
    services.AddSingleton<IAuthorizationPolicyProvider, MyAuthorizationPolicyProvider>();
