    internal static List<string> GetGroupsFromSignOn(string signOn)
    {
        string searchText = "(&(objectCategory=person)(objectClass=user)(sAMAccountName={0}))";
        searchText = searchText.Replace("{0}", signOn);
    
        Domain domain = Domain.GetCurrentDomain();
        DirectoryEntry userEntry = domain.GetDirectoryEntry();
    
        DirectorySearcher searcher = new DirectorySearcher(userEntry, searchText);
        SearchResult result = searcher.FindOne();
    
        DirectoryEntry currentUserEntry = result.GetDirectoryEntry();
    
        List<string> activedirectoryGroupList = new List<string>();
    
        if (currentUserEntry != null)
        {           
            int propertyCount = currentUserEntry.Properties["memberOf"].Count;
    
            string activedirectoryGroup;
    
            for (int i = 0; i < propertyCount; i++)
            {
                activedirectoryGroup = Convert.ToString(currentUserEntry.Properties["memberOf"][i]);
    
                int startIndex = activedirectoryGroup.IndexOf('=');
                startIndex += 1;
    
                int endIndex = activedirectoryGroup.IndexOf(',');
    
                int stringLength = endIndex - startIndex;
    
                activedirectoryGroup = activedirectoryGroup.Substring(startIndex, stringLength);
    
                activedirectoryGroupList.Add(activedirectoryGroup);
            }
    
            return activedirectoryGroupList;
        }
        else
        {
            return null;
        }
    }
