    [TestCase("LDAP://fully.qualified.domain.name", "TestUser1")] 
    public void GetNetBiosName(string ldapUrl, string login)
        string netBiosName = null;
        string foundLogin = null;
        using (DirectoryEntry root = new DirectoryEntry(ldapUrl))
            Using (DirectorySearcher searcher = new DirectorySearcher(root) {
                searcher.SearchScope = SearchScope.Subtree;
                searcher.PropertiesToLoad.Add("sAMAccountName");
                searcher.Filter = string.Format("(&(objectClass=user)(sAMAccountName={0}))", login);
                SearchResult result = null;
                try {
                    result = searcher.FindOne();
                    if (result == null) 
                        if (string.Equals(login, result.GetDirectoryEntry().Properties("sAMAccountName").Value)) 
                            foundLogin = result.GetDirectoryEntry().Properties("sAMAccountName").Value
                } finally {
                    searcher.Dispose();
                    root.Dispose();
                    if (result != null) result = null;
                }
            }
        if (!string.IsNullOrEmpty(foundLogin)) 
            using (DirectoryEntry root = new DirectoryEntry(ldapUrl.Insert(7, "CN=Partitions,CN=Configuration,DC=").Replace(".", ",DC=")) 
                Using DirectorySearcher searcher = new DirectorySearcher(root)
                    searcher.Filter = "nETBIOSName=*";
                    searcher.PropertiesToLoad.Add("cn");
                    SearchResultCollection results = null;
                    try {
                        results = searcher.FindAll();
                        if (results != null && results.Count > 0 && results[0] != null) {
                            ResultPropertyValueCollection values = results[0].Properties("cn");
                            netBiosName = rpvc[0].ToString();
                    } finally {
                        searcher.Dispose();
                        root.Dispose();
                        if (results != null) {
                            results.Dispose();
                            results = null;
                        }
                    }
                }
        Assert.AreEqual("FULLY\TESTUSER1", string.Concat(netBiosName, "\", foundLogin).ToUpperInvariant())
    }
