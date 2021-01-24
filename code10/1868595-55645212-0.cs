    if (!User.Identity.IsAuthenticated)
    {
        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, YourName));
        identity.AddClaim(new Claim(ClaimTypes.Name, YourName));
        identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
        //Add your custom claims
        var principal = new ClaimsPrincipal(identity);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = true });
    }
