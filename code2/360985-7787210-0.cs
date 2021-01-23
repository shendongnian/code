    private string GetNetBiosName(string ldapUrl, string userName, string password)
    {
       string netbiosName = string.Empty;
      DirectoryEntry dirEntry = new DirectoryEntry(ldapUrl,userName, password);
       DirectorySearcher searcher = new DirectorySearcher(dirEntry);
       searcher.Filter = "netbiosname=*";
       searcher.PropertiesToLoad.Add("cn");
       SearchResultCollection results = searcher.FindAll();
       if (results.Count > 0)
       {
        ResultPropertyValueCollection rpvc = results[0].Properties["CN"];
        netbiosName = rpvc[0].ToString();
       }
       return netbiosName;
   
    }
