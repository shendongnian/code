    var ValidatePrameters = new TokenValidationParameters
            {
                //Tlorance for Expire Time and Befor Time of Token .
                ClockSkew = TimeSpan.Zero,
                RequireSignedTokens = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(securityKey),
                // I Need Check Expire Token or Not
                RequireExpirationTime = true,
                ValidateLifetime = false,
                ValidateAudience = false,
                ValidAudience = siteSetting.JwtSetting.Audience,
                ValidateIssuer = false,
                ValidIssuer = siteSetting.JwtSetting.Issuer
            };
