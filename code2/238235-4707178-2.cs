    ConnectionStringSettingsCollection connections = ConfigurationManager.ConnectionStrings;
        
    if (connections.Count != 0)
    {
        foreach (ConnectionStringSettings connection in connections)
        {
            string name = connection.Name;
        }
    }
