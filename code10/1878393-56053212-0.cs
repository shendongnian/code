    public void ConfigureServices(IServiceCollection services)
    {
          // authentication with JWT
          services
            .AddAuthentication(o => o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(cfg =>
            {
                 cfg.Authority = Configuration["Authentication:Authority"];
                 cfg.Audience = Configuration["Authentication:ClientId"];
    
                 cfg.TokenValidationParameters = new TokenValidationParameters()
                 {
                     ValidateLifetime = true,
                     ValidateAudience = true,
                     ValidateIssuer = true,
                     RequireExpirationTime = true,
                     RequireSignedTokens = true
                 };
            });
    ...
