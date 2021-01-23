    // set up domain context
    PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
 
    // validate username/password credentials against AD
    if (ctx.ValidateCredentials(userName, password))
    {
       // do something
    }
    // getting current user and testing against group membership
    GroupPrincipal group = GroupPrincipal.FindByIdentity("YourGroup");
    UserPrincipal user = UserPrincipal.Current;
    if (user.IsMemberOf(group))
    {
       // do something
    }
