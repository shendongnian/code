    DirectoryEntry rootEntry = new DirectoryEntry("LDAP://some.ldap.server.com");
    rootEntry.AuthenticationType = AuthenticationTypes.None; //Or whatever it need be
    DirectorySearcher searcher = new DirectorySearcher(rootEntry);
    var queryFormat = "(&(objectClass=user)(objectCategory=person)(|(SAMAccountName=*{0}*)(cn=*{0}*)(gn=*{0}*)(sn=*{0}*)(email=*{0}*)))";
    searcher.Filter = string.Format(queryFormat, searchString);
    foreach(SearchResult result in searcher.FindAll()) 
    {
        Console.WriteLine("account name: {0}", result.Properties["samaccountname"].Count > 0 ? result.Properties["samaccountname"][0] : string.Empty);
        Console.WriteLine("common name: {0}", result.Properties["cn"].Count > 0 ? result.Properties["cn"][0] : string.Empty);
    }
