    var objSearchADAM = new DirectorySearcher();
    objSearchADAM.Filter = "(&(objectClass=group))";
    objSearchADAM.SearchScope = SearchScope.Subtree;
    var objSearchResults = objSearchADAM.FindAll();
    foreach (SearchResult objResult in objSearchResults)
    {
        using (var objGroupEntry = objResult.GetDirectoryEntry())
        {
            foreach (string child in objGroupEntry.Properties["member"])
            {
                var path = "LDAP://" + child.Replace("/", "\\/");
                using (var memberEntry = new DirectoryEntry(path))
                {
                    if (memberEntry.Properties.Contains("sAMAccountName"))
                    {
                        // Get sAMAccountName
                        string sAMAccountName = memberEntry.Properties["sAMAccountName"][0].ToString();
                        Console.WriteLine(sAMAccountName);
                    }
                    if (memberEntry.Properties.Contains("objectSid"))
                    {
                        // Get objectSid
                        byte[] sidBytes = (byte[]) memberEntry.Properties["objectSid"][0];
                        var sid = new System.Security.Principal.SecurityIdentifier(sidBytes, 0);
                        Console.WriteLine(sid.ToString());
                    }
                }
            }
        }
    }
