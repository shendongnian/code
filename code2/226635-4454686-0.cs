    string UserID = "grhm";
    using (var ctx = new PrincipalContext(ContextType.Domain))
    {
        var user UserPrincipal.FindByIdentity(ctx, UserID)
        if(usr != null)
        {
            userExists = true;
            usr.Dispose();
        }
    }
