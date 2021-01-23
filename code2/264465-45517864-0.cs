    List<string> DisplayedOU = new List<string>();
    int step = 0;
    string span = "<span style='margin-left:6px;'> -- </span>";
    private void getOU2()
    {
        string strRet = "";
        DirectoryEntry domainRoot = new DirectoryEntry("LDAP://uch.ac/OU=ALL,DC=uch,DC=ac", "user", "pass");
        // set up directory searcher based on default naming context entry
        DirectorySearcher ouSearcher = new DirectorySearcher(domainRoot);
        // SearchScope: OneLevel = only immediate subordinates (top-level OUs); 
        // subtree = all OU's in the whole domain (can take **LONG** time!)
        ouSearcher.SearchScope = SearchScope.Subtree;
        // ouSearcher.SearchScope = SearchScope.Subtree;
        // define properties to load - here I just get the "OU" attribute, the name of the OU
        ouSearcher.PropertiesToLoad.Add("ou");
        // define filter - only select organizational units
        ouSearcher.Filter = "(objectCategory=organizationalUnit)";
        int cnt = 0;
        foreach (SearchResult deResult in ouSearcher.FindAll())
        {
            string temp = deResult.Properties["ou"][0].ToString();
            strRet += FindSubOU(deResult.Properties["adspath"][0].ToString(), cnt);
            
        }
        Literal1.Text = strRet;
    }
    private string FindSubOU(string OU_Path, int cnt)
    {
        string strRet = "";
        DirectoryEntry domainRoot = new DirectoryEntry(OU_Path, "user", "pass");
        // set up directory searcher based on default naming context entry
        DirectorySearcher ouSearcher = new DirectorySearcher(domainRoot);
        // SearchScope: OneLevel = only immediate subordinates (top-level OUs); 
        // subtree = all OU's in the whole domain (can take **LONG** time!)
        ouSearcher.SearchScope = SearchScope.Subtree;
        // ouSearcher.SearchScope = SearchScope.Subtree;
        // define properties to load - here I just get the "OU" attribute, the name of the OU
        ouSearcher.PropertiesToLoad.Add("ou");
        // define filter - only select organizational units
        ouSearcher.Filter = "(objectCategory=organizationalUnit)";
        //adspath
        // do search and iterate over results
        foreach (SearchResult deResult in ouSearcher.FindAll())
        {
            string temp = deResult.Properties["ou"][0].ToString();
            if (!DisplayedOU.Contains(deResult.Properties["ou"][0].ToString()))
            {
                string strPerfix = "";
                for (int i = 0; i < step; i++)
                    strPerfix += span;
                strRet += strPerfix + ++cnt + ". " + deResult.Properties["ou"][0].ToString() + " ----> " + deResult.Properties["adspath"][0].ToString() + "<br />";
                DisplayedOU.Add(deResult.Properties["ou"][0].ToString());
                step++;
                strRet += FindSubOU(deResult.Properties["adspath"][0].ToString(), cnt);
                step--;
            }
        }
        return strRet;
    }
