    string UserID = "grhm";
    using (var ctx = new PrincipalContext(ContextType.Domain))
    {
        var user UserPrincipal.FindByIdentity(ctx, UserID)
        if(user != null)
        {
            userExists = true;
            user.Dispose();
        }
    }
