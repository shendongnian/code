    List<string> orgUnits = new List<string>();
    
    DirectoryEntry startingPoint = new DirectoryEntry("LDAP://DC=YourCompany,DC=com");
    
    DirectorySearcher searcher = new DirectorySearcher(startingPoint);
    searcher.Filter = "(objectCategory=organizationalUnit)";
    searcher.PropertiesToLoad.Add("displayName");
    
    foreach (SearchResult res in searcher.FindAll()) 
    {
       if(res.Properties["displayName"] != null)
       {
           orgUnits.Add(res.Properties["displayName"][0].ToString();
       }   
    }
    
