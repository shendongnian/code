    // Returns null if the name is not found.
    static string GetConnectionStringByName(string name)
    {
        string returnValue = null;   // Assume failure.
        var settings = ConfigurationManager.ConnectionStrings[name];
        if (settings != null) {
            returnValue = settings.ConnectionString;
		}
        return returnValue;
    }
