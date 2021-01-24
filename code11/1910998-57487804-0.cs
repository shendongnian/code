    services.AddAuthentication(options =>
    {
        options.DefaultScheme = "Cookies";
        options.DefaultChallengeScheme = "oidc";
    })
    .AddCookie("Cookies")
    .AddOpenIdConnect("oidc", options =>
    {
        options.SignInScheme = "Cookies";
        options.Authority = "http://localhost:5000";
        options.RequireHttpsMetadata = false;
        options.ClientId = "mvc";
        options.ClientSecret = "secret";
        options.ResponseType = "code id_token";
        options.SaveTokens = true;
        options.GetClaimsFromUserInfoEndpoint = true;
        options.Scope.Add("api1");
        options.Scope.Add("offline_access");
        options.Events = new OpenIdConnectEvents
        {
            
            OnTokenValidated = ctx =>
            {
                var clientID = ctx.SecurityToken.Claims.FirstOrDefault(c => c.Type == "aud")?.Value;
                var claims = new List<Claim>
                {
                    new Claim("ClientID", clientID)
                };
                var appIdentity = new ClaimsIdentity(claims);
                ctx.Principal.AddIdentity(appIdentity);
                return Task.CompletedTask;
            },
        };
    });
