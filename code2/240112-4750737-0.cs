    using System.DirectoryServices
    
    DirectoryEntry de = new DirectoryEntry();
    de.Path = "LDAP://**Your connection string here**";
    de.AuthenticationType = AuthenticationTypes.Secure;
    
    DirectorySearcher search = new DirectorySearcher(de);
    search.Filter = "(SAMAccountName=" + account + ")";
    //What properties do we want to return?
    search.PropertiesToLoad.Add("displayName");
    search.PropertiesToLoad.Add("mail");
    
    search.SearchScope = SearchScope.OneLevel //this makes it only search the specified level
    SearchResult result = search.FindOne();
    
    if (result != null)
    {
         //Get Him!    }
    else
    {
        //Not Found
    }
