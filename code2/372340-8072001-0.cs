    public static ????? GetUserProperty(string domainName, string usrName)
    {
       // set up domain context
       PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
       // find a user
       UserPrincipal user = UserPrincipal.FindByIdentity(ctx, usrName);
 
       if(user != null)
       {
          // return what you need to return from your user principal here
       }
       else
       {
           return null;
       }
    }
    
