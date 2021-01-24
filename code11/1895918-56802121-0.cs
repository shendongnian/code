        public void ConfigureServices(IServiceCollection services)
        {
        services.AddAuthentication(options =>
        {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
        options.Authority = "https://sts.windows.net/tenantId/v2.0";
        options.Audience = clientId;
        options.TokenValidationParameters.ValidateLifetime = true;
        });
        services.AddAuthorization();
        // Add framework services.
        services.AddMvc()
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }```
