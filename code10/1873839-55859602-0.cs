      var key = Encoding.ASCII.GetBytes(JWT.Key);
                services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidIssuer = JWT.Issuer,
                        LifetimeValidator =
                        (before, expires, token, parameters) =>
                        {
                           if (before.HasValue && before.Value > DateTime.Now)
                                return false;
    
                            if (expires.HasValue)
                                return expires.Value > DateTime.UtcNow;
    
                            //Otherwise the token is valid
                            return true;
                        },
                        ValidateLifetime = true,
                    };
                });
