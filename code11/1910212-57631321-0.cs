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
    
        options.Scope.Add("athlete.full");
        options.Scope.Add("rights");
        options.Scope.Add("email");
        options.Scope.Add("address");
        options.Scope.Add("phone");
    
        options.Scope.Add("offline_access");
    
        // These are what allowed the claims to be serialized for front-end consumption.
        options.ClaimActions.MapJsonKey(JwtClaimTypes.WebSite, "website");
        options.ClaimActions.MapJsonKey(JwtClaimTypes.Gender, "gender");
        options.ClaimActions.MapJsonKey(JwtClaimTypes.BirthDate, "birthdate");
    });
