    // Returns null if the name is not found.
    static string GetConnectionStringByName(string name)
    {
        // Assume failure.
        string returnValue = null;
    
        // Look for the name in the connectionStrings section.
        ConnectionStringSettings settings =
            ConfigurationManager.ConnectionStrings[name];
    
        // If found, return the connection string.
        if (settings != null)
            returnValue = settings.ConnectionString;
    
        return returnValue;
    }
