return services.Configure<JwtBearerOptions>(AzureADDefaults.JwtBearerAuthenticationScheme, options =>
             {
                 // This is an Azure AD v2.0 Web API
                 options.Authority += "/v2.0";
                 // The valid audiences are both the Client ID (options.Audience) and api://{ClientID}
                 options.TokenValidationParameters.ValidAudiences = new string[] { options.Audience, $"api://{options.Audience}" };
                
                 options.TokenValidationParameters.ValidateIssuer = false;
             });
Note: the link above provided an alternative solution to turning off the validation of the issuer if anyone is interested.
My AppSettings file was also simplified by only needing to define the Instance, TenantId, and ClientId.
Then from a swagger perspective, I just needed to add an additional scope to the security definition matching the one I created in my AAD application.
          c.AddSecurityDefinition("oauth2", new OAuth2Scheme
                {
                    Type = "oauth2",
                    Flow = "implicit",
                    AuthorizationUrl = "https://login.microsoftonline.com/common/oauth2/v2.0/authorize",
                    TokenUrl = "https://login.microsoftonline.com/common/oauth2/v2.0/token",
                    Scopes = new Dictionary<string, string>
                   {
                       { "openid", "Sign In Permissions" },
                       { "profile", "User Profile Permissions" },
                       { $"api://{clientId}/access_as_user", "Application API Permissions" }
                   }
                });
After these changes my application is now working as expected.
