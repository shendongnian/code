    public static List<string> GetLoggedOnUsers(CacheLevel level)
    {
        const int ConsoleSession = 2;
        string logonQuery = "SELECT * FROM Win32_LogonSession WHERE LogonType = " + ConsoleSession;
        ManagementObjectSearcher searcher = new ManagementObjectSearcher(logonQuery);
        List<string> userNames = new List<string>();
        foreach (ManagementBaseObject logon in searcher.Get())
        {
            string logonId = logon.Properties["LogonId"].Value.ToString();
            string userQuery = "ASSOCIATORS OF {Win32_LogonSession.LogonId=" + logonId + "} "
                               + "WHERE AssocClass=Win32_LoggedOnUser Role=Dependent";
            ManagementObjectSearcher searcher2 = new ManagementObjectSearcher(userQuery);
            foreach (ManagementBaseObject user in searcher2.Get())
            {
                string name = user.Properties["FullName"].Value.ToString();
                userNames.Add(name);
            }
        }
        return userNames.Distinct().ToList();
    }
