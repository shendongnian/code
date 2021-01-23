    string defaultNamingContext;
    
    using (DirectoryEntry rootDSE = new DirectoryEntry("LDAP://rootDSE", null, null, AuthenticationTypes.Anonymous))
    {
        defaultNamingContext = rootDSE.Properties["defaultNamingContext"].Value.ToString();
    }
