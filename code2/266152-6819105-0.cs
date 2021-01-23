    foreach (RasConnection conn in RasConnection.GetActiveConnections())
    {
        RasConnectionStatus status = conn.GetConnectionStatus();
        // Do something useful.
    }
