cshtml
services.AddSingleton<IManageJwtAuthentication, JwtAuthenticationManager>();
services.AddOptions<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme)
    .Configure<IManageJwtAuthentication>((opts,jwtAuthManager)=>{
        opts.TokenValidationParameters = new TokenValidationParameters
        {
            AudienceValidator = jwtAuthManager.AudienceValidator,
            // More code here...
        };
    });
services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();
