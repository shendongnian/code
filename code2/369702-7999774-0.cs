    public static string GetUserLocation(string userName)
    {            
        string userLoc = "";
        DirectoryEntry entry = new DirectoryEntry("LDAP://FTLAD04.corp.myDomain.com");
        DirectorySearcher dSearch = new DirectorySearcher(entry);
        dSearch.Filter = "(&(objectClass=user)(samAccountName=" + userName + "))";
        dSearch.PropertiesToLoad.Add("l");
        SearchResult result = dSearch.FindOne();
        if(result != null)
        {
           if(result.Properties["l"] != null && result.Properties["l"].Count > 0)
           {
              string location =  result.Properties["l"][0].ToString();
           }
        }
        return userLoc;
    }
