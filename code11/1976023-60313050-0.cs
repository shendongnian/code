    services.ConfigureApplicationCookie(opt => {
        opt.Events.OnSigningIn = async (signinContext) => {
            // you can use the pricipal to query claims 
            var email = signinContext.Principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            if ("xxxx@hotmail.com".Equals(email))
            {
                // set the expiration time according to claims dynamically 
                signinContext.Properties.ExpiresUtc = DateTimeOffset.Now.AddSeconds(100);
                signinContext.CookieOptions.Expires = signinContext.Properties.ExpiresUtc?.ToUniversalTime();
            }
            else
            {
                signinContext.Properties.ExpiresUtc = DateTimeOffset.Now.AddMinutes(60);
                signinContext.CookieOptions.Expires = signinContext.Properties.ExpiresUtc?.ToUniversalTime();
            }      
        
        };
    });
