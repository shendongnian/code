    var authenticateResult = await HttpContextAccessor.HttpContext.AuthenticateAsync(
        CookieAuthenticationDefaults.AuthenticationScheme);
    if (authenticateResult.Succeeded)
    {
        var expiresUtc = authenticateResult.Properties.ExpiresUtc;
    }
