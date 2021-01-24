    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
    
            RoleClaimType = "role" // same name as in your JWT token, as by default it is 
            // "http://schemas.microsoft.com/ws/2008/06/identity/claims/role" 
        };
        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = context =>
            {
                var jwt = (context.SecurityToken as JwtSecurityToken)?.ToString();
                // get your JWT token here if you need to decode it e.g on https://jwt.io
                // And you can re-add role claim if it has different name in token compared to what you want to use in your ClaimIdentity:  
                AddRoleClaims(context.Principal);
                return Task.CompletedTask;
            }
        };
    });
    private static void AddRoleClaims(ClaimsPrincipal principal)
    {
        var claimsIdentity = principal.Identity as ClaimsIdentity;
        if (claimsIdentity != null)
        {
            if (claimsIdentity.HasClaim("role", "AdminRoleNameFromToken"))
            {
                if (!claimsIdentity.HasClaim("role", Role.Administrator.ToString()))
                {
                    claimsIdentity.AddClaim(new Claim("role", Role.Administrator.ToString()));
                }
            }
        }
    }
