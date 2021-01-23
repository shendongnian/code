    private IEnumerable<DirectoryEntry> GetDomains() {
        ICollection<string> domains = new List<string>();
        // Querying the current Forest for the domains within.
        foreach(Domain d in Forest.GetCurrentForest().Domains)
            domains.Add(d.Name);
        return domains;
    }
    private string GetDomainFullName(string friendlyName) {
        DirectoryContext context = new DirectoryContext(DirectoryContextType.Domain, friendlyName);
        Domain domain = Domain.GetDomain(context);
        return domain.Name;
    }
    private IEnumerable<string> GetUserDomain(string userName) {
        foreach(string d in GetDomains()) 
            // From the domains obtained from the Forest, we search the domain subtree for the given userName.
            using (DirectoryEntry domain = new DirectoryEntry(GetDomainFullName(d))) {
                using (DirectorySearcher searcher = new DirectorySearcher()){
                    searcher.SearchRoot = domain;
                    searcher.SearchScope = SearchScope.Subtree;
                    searcher.PropertiesToLoad.Add("sAMAccountName");
                    // The Filter is very important, so is its query string. The 'objectClass' parameter is mandatory.
                    // Once we specified the 'objectClass', we want to look for the user whose login
                    // login is userName.
                    searcher.Filter = string.Format("(&(objectClass=user)(sAMAccountName={0}))", userName);
                    try {
                        SearchResultCollection  results = searcher.FindAll();
              
                        // If the user cannot be found, then let's check next domain.
                        if (results == null || results.Count = 0)
                            continue;
                         // Here, we yield return for we want all of the domain which this userName is authenticated.
                         yield return domain.Path;
                    } finally {
                        searcher.Dispose();
                        domain.Dispose();
                    }
                }
    }
