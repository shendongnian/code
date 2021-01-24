    // TokenController.cs
    // ...
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> ActionAsync()
    {
        // NEW
        var provider = HttpContext.RequestServices.GetService<IAuthenticationHandlerProvider>();
        // NEW
        var handler = await provider.GetHandlerAsync(HttpContext, "MY_AUTH_SCHEME") as
            AuthenticationHandler<JwtBearerOptions>;
        // NEW
        var jwtBearerOptions = handler.Options;
        using (var stream = new MemoryStream())
        using (var reader = new StreamReader(stream))
        {
            await Request.Body.CopyToAsync(stream);
            stream.Seek(0, SeekOrigin.Begin);
    
            var jwt = await reader.ReadToEndAsync();
            // NEW
            var tokenValidationParameters = jwtBearerOptions.TokenValidationParameters;
    
            // ...
        }
        // ...
    }
    // ...
