    public static string HashGroups(string user)
    {
        DirectoryEntry directoryEntry = default(DirectoryEntry);
        DirectorySearcher dirSearcher = default(DirectorySearcher);
        List<string> result = new List<string>();
        directoryEntry = new DirectoryEntry("LDAP://<YOUR_DOMAIN>");
        directoryEntry.RefreshCache();
        // Get search object, specify filter and scope, 
        // perform search. 
        dirSearcher = new DirectorySearcher(directoryEntry);
        dirSearcher.PropertiesToLoad.Add("memberOf");
        dirSearcher.Filter = "(&(sAMAccountName=" + user + "))";
        SearchResult sr = dirSearcher.FindOne();
        // Enumerate groups 
        foreach (string group in sr.Properties["memberOf"])
        {
            result.Add(group);
        }
        // OrderBy is important! Otherwise, your hash might fail because 
        // the groups come back in different order.
        MD5 md5 = MD5.Create();
        Byte[] inputBytes = Encoding.ASCII.GetBytes(result.OrderBy(s1 => s1).SelectMany(s2 => s2).ToArray());
        byte[] hash = md5.ComputeHash(inputBytes);
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("X2"));
        }
        return sb.ToString();
    }
