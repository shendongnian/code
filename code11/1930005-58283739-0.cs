    public ClaimsPrincipal GetClaims(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var validations = new TokenValidationParameters
        {
             ValidateIssuerSigningKey = true,
             IssuerSigningKey = SIGNING_KEY,
             ValidateIssuer = false,
             ValidateAudience = false
        };
    
        return handler.ValidateToken(token, validations, out var tokenSecure);
    }
