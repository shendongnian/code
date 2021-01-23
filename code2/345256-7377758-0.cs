    public static void InitializeService(DataServiceConfiguration config)
    {
        var context = ServiceSecurityContext.Current;
        if (context != null && context.PrimaryIdentity != null)
        {
            var userName = context.PrimaryIdentity.Name;
            if (SomeMethodToValidateUserPermissions(userName)
            {
                config.SetEntitySetAccessRule("Users", EntitySetRights.AllRead);
            }
        }
        config.SetEntitySetAccessRule("TrimmedUsers", EntitySetRights.AllRead);
    } 
