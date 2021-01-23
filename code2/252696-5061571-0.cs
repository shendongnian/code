    DirectoryEntry rootDSE = new DirectoryEntry("LDAP://RootDSE");
    string domainContext = rootDSE.Properties["defaultNamingContext"].Value as string;
    DirectoryEntry searchRoot = new DirectoryEntry("LDAP://" + domainContext);
    using (DirectorySearcher searcher = new DirectorySearcher(
        searchRoot, 
        "(&(objectCategory=person)(objectClass=contact))", 
        new string[] {"targetAddress"}, 
        SearchScope.Subtree))
    {
        foreach (SearchResult result in searcher.FindAll())
        {
            foreach (string addr in result.Properties["targetAddress"])
            {        
               Console.WriteLine(addr);
            }
            Console.WriteLine(result.Path);
        }
    }
