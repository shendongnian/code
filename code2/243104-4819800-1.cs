    try
    {
        System.DirectoryServices.DirectoryEntry AdRootDSE = new System.DirectoryServices.DirectoryEntry("LDAP://rootDSE");
        string rootdse = System.Convert.ToString(AdRootDSE.Properties["defaultNamingContext"].Value);
        if (!rootdse.StartsWith("LDAP://", StringComparison.OrdinalIgnoreCase) && !rootdse.StartsWith("LDAPS://", StringComparison.OrdinalIgnoreCase))
        {
            rootdse = "LDAP://" + rootdse;
        }
        return rootdse;
    }
    catch (Exception ex)
    {
    }
