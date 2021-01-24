    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddCustomJwtBearer(options =>
            {
                options.TokenValidationParameters = tokenParams;
                options.Events = ConfigureJwtEvents(tokenConfiguration);
            });
