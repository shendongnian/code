    public string GetLoginName(string userName)
    {
      // set up domain context
      PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
      // find user by name
      UserPrincipal user = UserPrincipal.FindByIdentity(ctx, userName);
 
      if(user != null)
           return user.SamAccountName;
      else
           return string.Empty;
    }
