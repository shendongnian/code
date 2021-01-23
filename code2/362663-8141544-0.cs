    using (DirectoryEntry root = new DirectoryEntry("WinNT:"))
    {
        ITerminalServicesManager tsm = new Cassia.TerminalServicesManager();
        foreach (DirectoryEntry computers in root.Children)
        foreach (DirectoryEntry computer in computers.Children)
        {
            if ((computer.Name != "Schema"))
            {
                string linqCapture = computer.Name; //<-- This may not be necessary, 
                                                    //but I have always have had bad
                                                    //experiences with LINQ and foreach
                                                    //loops not capturing the current
                                                    //value of the variable correctly.
                //remove the last Where clause if you want all users connected 
                //to the computer, not just the one where it is the console session.
                foreach(var session in tsm.GetSessions(linqCapture)
                                          .Where(s => s.ConnectionState == ConnectionState.Active)
                                          .Where(s => s.ClientName == linqCapture))
                {
                    string LoggedInUser = session.UserName;
                    System.Net.IPAddress LoggedInIp = session.ClientIPAddress;
                    //Do with data what ever you want to;
                }
            }
        }
    }
