    public static Dictionary<string,string> ExistingConnections()
    {
        var connections = ConfigurationManager.ConnectionStrings.Cast<ConnectionStringSettings>().Where(connection => connection.ProviderName == "Camelot.SharePointProvider").ToDictionary(connection => connection.ProviderName, connection => connection.ConnectionString);
        return connections.Count > 0 ? connections : null;
    }
