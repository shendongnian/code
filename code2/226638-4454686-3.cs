    string UserID = "grhm";
    bool userExists = false;
    using (var ctx = new PrincipalContext(ContextType.Domain))
    {
        using (var user = UserPrincipal.FindByIdentity(ctx, UserID))
        {
            if (user != null)
            {
                userExists = true;
                user.Dispose();
            }
        }
    }
