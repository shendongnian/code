    internal ServiceSecurityContext Create(Credentials credentials)
    {
       var authorizationPolicies = new List<iauthorizationpolicy>();
       authorizationPolicies.Add(authorizationPolicyFactory.Create(credentials));
       return new ServiceSecurityContext(authorizationPolicies.AsReadOnly());
    }
