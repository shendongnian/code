    // set up domain context
    PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
    // validate username/password combo
    if (ctx.ValidateCredentials(username, password))
    {
       // if valid - find user
       UserPrincipal user = UserPrincipal.FindByIdentity(ctx, username);
       if (user != null)
       {
                    return user.EmailAddress;
       }
    }
    
