    if (HttpContext.User.Identity is ClaimsIdentity identity)
    {
      
        identity.AddClaim(new Claim("userId", "1234"));
        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(HttpContext.User.Identity));
    }
