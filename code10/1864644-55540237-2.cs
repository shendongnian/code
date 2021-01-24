    public static void ConfigureAuthentication(IAppBuilder app)
        {
            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
               new WindowsAzureActiveDirectoryBearerAuthenticationOptions
               {
                   Tenant = Configuration["AzureAD.TenantId"],
                   TokenValidationParameters = new TokenValidationParameters()
                   {
                       ValidateIssuer = true,
                       ValidIssuer = Configuration["AzureAD.Issuer"],
                       ValidAudience = Configuration["AzureAD.Audience"],
                       ValidateLifetime = true
                   }
               });
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = Configuration["AzureAD.Issuer"],
                        ValidAudience = Configuration["AzureAD.Audience"],
                        ValidateLifetime = true
                    }
                });
        }
