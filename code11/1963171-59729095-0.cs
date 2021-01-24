    public async Task ValidateAsync(ExtensionGrantValidationContext context)
    {
        var userToken = context.Request.Raw.Get("token");
        if (string.IsNullOrEmpty(userToken))
        {
        context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant);
        return;
        }
        var result = await _validator.ValidateAccessTokenAsync(userToken);
        if (result.IsError)
        {
            context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant);
            return;
        }
    
        var sub = result.Claims.FirstOrDefault(c => c.Type == JwtClaimTypes.Subject)?.Value;
        var username = result.Claims.FirstOrDefault(c => c.Type == JwtClaimTypes.Name)?.Value;
        var other = result.Claims.FirstOrDefault(c => c.Type == "other")?.Value;
        // ...
        var claims = new List<Claim>();
        claims.Add(new Claim(JwtClaimTypes.Subject, sub));
        claims.Add(new Claim(JwtClaimTypes.Subject, username));
        claims.Add(new Claim(JwtClaimTypes.Subject, other));
        // ...
        context.Result = new GrantValidationResult(subject: sub, authenticationMethod: GrantType, claims: claims);
        return;
    }
