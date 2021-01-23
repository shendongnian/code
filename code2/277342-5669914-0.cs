    ITerminalServicesManager manager = new TerminalServicesManager();
    using (ITerminalServer server = manager.GetRemoteServer("your-server-name"))
    {
        server.Open();
        foreach (ITerminalServicesSession session in server.GetSessions())
        {
            Console.WriteLine("Session ID: " + session.SessionId);
            Console.WriteLine("User: " + session.UserAccount);
            Console.WriteLine("State: " + session.ConnectionState);
            Console.WriteLine("Logon Time: " + session.LoginTime);
        }
    }
