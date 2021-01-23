    internal class AuthorizationPolicyFactory
    {
       public virtual IAuthorizationPolicy Create(Credentials credentials)
       {
          var genericIdentity = new GenericIdentity(credentials.UserName);
          var genericPrincipal = new GenericPrincipal(genericIdentity,
                                                      new string[] { });
          return new PrincipalAuthorizationPolicy(genericPrincipal);
       }
    }
