    var authenticateResult = await HttpContextAccessor.HttpContext.SignInAsync(
        CookieAuthenticationDefaults.AuthenticationScheme);
    if (authenticateResult.Succeeded)
    {
        var expiresUtc = authenticateResult.Properties.ExpiresUtc;
    }
