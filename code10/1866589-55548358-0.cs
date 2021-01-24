    .AddOpenIdConnect(o =>
        {
            //Additional config snipped
            o.Events = new OpenIdConnectEvents
            {
                OnTokenValidated = async ctx =>
                {
                    //Get user's immutable object id from claims that came from Azure AD
                    string oid = ctx.Principal.FindFirstValue("http://schemas.microsoft.com/identity/claims/objectidentifier");
    
                    //Get EF context
                    var db = ctx.HttpContext.RequestServices.GetRequiredService<AuthorizationDbContext>();
    
                    //Check is user a super admin
                    bool isSuperAdmin = await db.SuperAdmins.AnyAsync(a => a.ObjectId == oid);
                    if (isSuperAdmin)
                    {
                        //Add claim if they are
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Role, "superadmin")
                        };
                        var appIdentity = new ClaimsIdentity(claims);
    
                        ctx.Principal.AddIdentity(appIdentity);
                    }
                }
            };
    });
