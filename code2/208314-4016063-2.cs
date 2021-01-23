    public static string RetrieveRootDseDefaultNamingContext()
    {
        String RootDsePath = "LDAP://RootDSE";
        const string DefaultNamingContextPropertyName = "defaultNamingContext";
        DirectoryEntry rootDse = new DirectoryEntry(RootDsePath)
        {
            AuthenticationType = AuthenticationTypes.Secure;
        };
        object propertyValue = rootDse.Properties[DefaultNamingContextPropertyName].Value;
        return propertyValue != null ? propertyValue.ToString() : null;
    }
