        TimeSpan tokenExpiration = TimeSpan.FromDays(1);
        ClaimsIdentity identity = new ClaimsIdentity(OAuthDefaults.AuthenticationType);
        identity.AddClaim(new Claim(ClaimTypes.Name, "a@a.com"));
        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, "999"));
        AuthenticationProperties props = new AuthenticationProperties()
        {
            IssuedUtc = DateTime.UtcNow,
            ExpiresUtc = DateTime.UtcNow.Add(tokenExpiration),
        };
        AuthenticationTicket ticket = new AuthenticationTicket(identity, props);
        string accessToken = Startup.AccessTokenFormat.Protect(ticket);
