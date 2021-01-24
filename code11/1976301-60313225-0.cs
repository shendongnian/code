    public void ExpireToken(IServiceProvider services, string tokenId)
    {
        var jwtManager = services.GetService<IJWTAuthenticationManager>();
        jwtManager.ExpireToken(tokenId);
    }
