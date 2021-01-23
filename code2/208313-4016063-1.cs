     public static string RetrieveRootDseDefaultNamingContext()
     {
        string returnValue = string.Empty;
        try
        {
            String RootDsePath = "LDAP://RootDSE";
            String DefaultNamingContextPropertyName = "defaultNamingContext";
            DirectoryEntry rootDse = new DirectoryEntry(RootDsePath);
            rootDse.AuthenticationType = AuthenticationTypes.Secure;
    
            PropertyValueCollection propertyValues = rootDse.Properties[DefaultNamingContextPropertyName];
            object propertyValue = propertyValues.Value;
            if (propertyValue != null)
            {
                returnValue = propertyValue.ToString();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    
        return returnValue;
    }
