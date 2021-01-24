    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKeyResolver = (s, securityToken, identifier, parameters) =>
        {
            // get from provider 
            // todo: cache this
            var json = new WebClient().DownloadString(
                 issuer + "/.well-known/jwks.json"); //typical endpoint
            // serialize the result
            var keys = JsonConvert.DeserializeObject<JsonWebKeySet>(json).Keys;
            // cast the result to be the type expected by IssuerSigningKeyResolver
            return (IEnumerable<SecurityKey>) keys;
        }
    //...
