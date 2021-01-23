    public string GetDomainUser(string userName) {
        string userDomain = null;
        using (DirectoryEntry root = new DirectoryEntry("LDAP://fully.qualified.domain.name"))
            using (DirectorySearcher searcher = new DirectorySearcher()) {
                searcher.SearchRoot = root;
                searcher.SearchScope = SearchScope.Subtree;
                searcher.PropertiesToLoad.Add("nETBIOSName");
                searcher.Filter = string.Format("(&(objectClass=user)(sAMAccountName={0}))", userNameToSearchFor);
                SearchResult result = null;
 
                try {
                    result = searcher.FindOne();
                
                    if (result != null)
                       userDomain = (string)result.GetDirectoryEntry().Properties("nETBIOSName").Value;
                } finally {
                    searcher.Dispose();
                    root.Dispose();
                    
                    if (result != null)
                        result = null;
                }
            }
        return userDomain;
    }
    
