    public static bool isInRole(UserAccount userAccount, string groupName)
    {
       using (var ctx = new PrincipalContext(ContextType.Domain, userAccount.DomainName))
       using (var user = UserPrincipal.FindByIdentity(ctx, userAccount.UserName))
       {
          bool isInRole = user != null &&
                          user.GetAuthorizationGroups()
                          .Any(g => g.Name == groupName);
          return isInRole;
       }
    }
