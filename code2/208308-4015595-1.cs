    using (var context = new System.DirectoryServices.AccountManagement.PrincipalContext(ContextType.Domain))
    {
        string server = context.ConnectedServer; // "pdc.examle.com"
        string[] splitted = server.Split('.'); // { "pdc", "example", "com" }
        var formatted = splitted.Select(s => "DC=" + s)); // { "DC=pdc", "DC=example", "DC=com" }
        string joined = String.Join(",", formatted); // "DC=pdc,DC=example,DC=com"
        // or just in one string
        string pdc = String.Join(",", context.ConnectedServer.Split('.').Select(s => "DC=" + s));
    }
