    services.AddJwtBearer(options =>
    {
        ...
    
        options.Events = new JwtBearerEvents
        {
    
            OnTokenValidated = async ctx =>
            {
                // 1. grabs the user id from firebase
                var name = ctx.Principal.Claims.First(c => c.Type == "user_id").Value;
    
                // Get userManager out of DI
                var _userManager = ctx.HttpContext.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();
    
                // 2. retrieves the roles that the user has
                ApplicationUser user = await _userManager.FindByNameAsync(name);
                var userRoles = await _userManager.GetRolesAsync(user);
    
                //3.  adds the role as a new claim 
                ClaimsIdentity identity = ctx.Principal.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    foreach (var role in userRoles)
                    {
                        identity.AddClaim(new System.Security.Claims.Claim(ClaimTypes.Role, role));
                    }
                }
    
            }
    
        };
    });
