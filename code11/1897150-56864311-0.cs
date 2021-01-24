    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        
        var claims = new[] { new Claim(ClaimTypes.Name, "nanyu") };
        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);
        return AuthenticateResult.Success(ticket);
    }
