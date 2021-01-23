    SearchResult result = searcher.FindOne();
    
    if(result != null)
    {
        DirectoryEntry directoryEntry = result.GetDirectoryEntry();
        if(directoryEntry.Properties["displayName"] != null &&
           directoryEntry.Properties["displayName"].Length > 0)
        {
           string displayName = directoryEntry.Properties["displayName"][0].ToString();
    
           if (!string.IsNullOrEmpty(displayName))
           {
              return displayName;
           }
        }
    }
    
