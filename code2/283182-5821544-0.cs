    // set up domain context
    PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
    // find user by name
    UserPrincipal user = UserPrincipal.FindByIdentity("John Doe");
    if(user != null)
    {
       // check if account is locked out
       if(user.IsAccountLockedOut)
       {
          // do something if locked out....
       }
    }
 
