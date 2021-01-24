    new Client
    {
        ClientId = "mvc",
        ClientName = "MVC Client",
        AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
        
        ....
        ....
        AlwaysIncludeUserClaimsInIdToken = true,
        AllowedScopes =
        {
            IdentityServerConstants.StandardScopes.OpenId,
            IdentityServerConstants.StandardScopes.Profile,
            "api1",
            IdentityServerConstants.StandardScopes.Email,
        },
        AllowOfflineAccess = true
    },
