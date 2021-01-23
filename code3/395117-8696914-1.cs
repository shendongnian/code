    // Get the default adapter
    string defaultAdapter = Registry.GetValue(@"HKEY_CURRENT_USER\RemoteAccess", "InternetProfile", "") as string;
    
    foreach (RasConnection connection in RasConnection.GetActiveConnections())
    {
        if (connection.EntryName.Equals(defaultAdapter, StringComparison.InvariantCultureIgnoreCase))
        {
            if (connection.GetConnectionStatus().ConnectionState == RasConnectionState.Connected)
            {
                 // Do something
            }
        }
        // Done searching
        break;
    }
