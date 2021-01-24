        class ClaimsTransformer : IClaimsTransformation
        {
            public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
            {
                var id = ((ClaimsIdentity)principal.Identity);
                var ci = new ClaimsIdentity(id.Claims, id.AuthenticationType, id.NameClaimType, id.RoleClaimType);
                //read database or flies or query AD to confirm user role by use ci.Name(username)
                if (....)
                {
                    ci.AddClaim(new Claim("role", "Admin"));
                }
                else
                {
                    ci.AddClaim(new Claim("role", "user"));
               
                }
            
                var cp = new ClaimsPrincipal(ci);
                return Task.FromResult(cp);
            }
        }
