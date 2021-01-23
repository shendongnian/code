    RasDialer dialer = new RasDialer();
    
    bool connected = false;
    foreach (RasConnection connection in dialer.GetActiveConnections())
    {
        if (connection.EntryName == "MyFriendsPC")
        {
            connected = true;
            break;
        }
    }
    
    if (!connected) {
        dialer.EntryName = "MyFriendsPC";
        dialer.Dial();
    
        // If you need to provide credentials, use the Dial(NetworkCredential) overload that's available.
    }
