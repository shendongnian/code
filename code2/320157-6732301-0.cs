    public static Dictionary<string,string> ExistingConnections()
    {
        var connections = new Dictionary<string, string>();
        foreach (ConnectionStringSettings connection in ConfigurationManager.ConnectionStrings)
        {
            if(connection.ProviderName == "sql.providername")
                connections.Add(connection.ProviderName, connection.ConnectionString);
        }
        return connections.Count > 0 ? connections : null;
    }
