    [AllowAnonymous]
    [DisableRequestSizeLimit]
    [HttpGet("loginCallback")]
    public IActionResult IamCallback()
    {
        //
        // Read external identity from the temporary cookie
        //
        var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        
        if (result?.Succeeded != true)
        {
            throw new Exception("Nein");
        }
        var oauthUser = result.Principal;
        ...
        return Ok();
    }
