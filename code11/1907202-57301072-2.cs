    options.Events = new Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents
                {
                    OnTokenValidated = (context) =>
                    {
                        var claimsIdentity = (ClaimsIdentity)context.Principal.Identity;
                        //add your custom claims here
                        claimsIdentity.AddClaim(new Claim("schema", "AAD"));
                        return Task.FromResult(0);
                    }
                };
