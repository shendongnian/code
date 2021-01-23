    private string _dotComRootPath = "LDAP://ktregression.com";
    private string _dotRootRootPath = "LDAP://ktregression.root";
    private string _serviceAccountLogin = "MyWindowsServiceAccountLogin";
    private string _serviceAccountPwd = "MyWindowsServiceAccountPassword";
    public string GetUserDomain(string rootPath, string login) {
        string userDomain = null;
        using (DirectoryEntry root = new DirectoryEntry(rootPath, _serviceAccountLogin, _serviceAccountPwd)) 
            using (DirectorySearcher searcher = new DirectorySearcher()) {
                searcher.SearchRoot = root;
                searcher.SearchScope = SearchScope.Subtree;
                searcher.PropertiesToLoad.Add("nETBIOSName");
                searcher.Filter = string.Format("(&(objectClass=user)(sAMAccountName={0}))", login);
                
                SearchResult result = null;
                try {
                    result = searcher.FindOne();
                    if (result != null) 
                        userDomain = (string)result.GetDirectoryEntry()
                                        .Properties("nETBIOSName").Value;                                     
                } finally {
                    dotComRoot.Dispose();
                    dotRootRoot.Dispose();
                    if (result != null) result.Dispose();
                }
            }            
        return userDomain;
    }
