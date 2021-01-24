    [HttpGet("{scheme?}")]
    public IActionResult SignOut([FromRoute] string scheme)
    {
        scheme = scheme ?? AzureADDefaults.AuthenticationScheme;
        var options = Options.Get(scheme);
        var callbackUrl = Url.Page("/Account/SignedOut", pageHandler: null, values: null, protocol: Request.Scheme);
        return SignOut(
            new AuthenticationProperties { RedirectUri = callbackUrl },
            options.CookieSchemeName,
            options.OpenIdConnectSchemeName);
    }
