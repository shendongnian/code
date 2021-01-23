    PrincipalContext oPrincipalContext = new PrincipalContext(ContextType.Machine, computer.Name, null, ContextOptions.Negotiate, Settings.UserName, Settings.UserPassword);
    try
    {
        GroupPrincipal oGroupPrincipal = GroupPrincipal.FindByIdentity(oPrincipalContext, Settings.AdministratorsGroup);
        try
        {
            // perform operations here
        }
        finally
        {
            oGroupPrincipal.Dispose();
        }
    }
    finally
    {
        oPrincipalContext.Dispose();
    }
