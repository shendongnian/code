    services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")
            .AddOpenIdConnect("oidc", options =>
            {
                options.SignInScheme = "Cookies";
                options.Authority = "Identity URL ";
                options.RequireHttpsMetadata = true;
                options.ClientId = "saas_crm_webclient";
                options.ClientSecret = "49C1A7E1-0C79-4A89-A3D6-A37998FB86B0";
                options.ResponseType = "code id_token";
                options.SaveTokens = true;
                options.GetClaimsFromUserInfoEndpoint = false;
                options.Scope.Add("test.api");
                options.Scope.Add("identity.api");
                options.Scope.Add("offline_access");
                **options.ClaimActions.Add(new JsonKeyClaimAction("role", null, "role"));**
                **options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    NameClaimType = "name",
                    RoleClaimType = "role"
                };**
            });
