    using (var context = new System.DirectoryServices.AccountManagement.PrincipalContext(ContextType.Domain))
    {
        string server = context.ConnectedServer; // "pdc.examle.com"
        string[] splitted = server.Split('.'); // { "pdc", "example", "com" }
        IEnumerable<string> formatted = splitted.Select(s => String.Format("DC={0}", s));// { "DC=pdc", "DC=example", "DC=com" }
        string joined = String.Join(",", formatted); // "DC=pdc,DC=example,DC=com"
        // or just in one string
        string pdc = String.Join(",", context.ConnectedServer.Split('.').Select(s => String.Format("DC={0}", s)));
    }
