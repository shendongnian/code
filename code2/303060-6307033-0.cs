    public bool UserExists(string username)
    {
       DirectoryEntry de = GetDirectoryEntry();
       DirectorySearcher deSearch = new DirectorySearcher();
       deSearch.SearchRoot = de;
       deSearch.Filter = "(&(objectClass=user) (cn=" + username + "))";
       SearchResultCollection results = deSearch.FindAll();
       return results.Count > 0;
    }
    private String FindName(String userAccount)
    {
       DirectoryEntry entry = GetDirectoryEntry();
       String account = userAccount.Replace(@"Domain\", "");
       try
       {
          DirectorySearcher search = new DirectorySearcher(entry);
          search.Filter = "(SAMAccountName=" + account + ")";
          search.PropertiesToLoad.Add("displayName");
          SearchResult result = search.FindOne();
          if (result != null)
          {
             return result.Properties["displayname"][0].ToString();
          }
          else
          {
             return "Unknown User";
          }
       }
       catch (Exception ex)
       {
          string debug = ex.Message;
    
          return "";
       }
    }
