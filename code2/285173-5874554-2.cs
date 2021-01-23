       static List<DirectoryEntry> OuInTheFormOf(DirectoryEntry deBase, string ou1, string ou2)
        {
          List<DirectoryEntry> deList = null;
    
          /* Directory Search
           */
          DirectorySearcher dsLookFor = new DirectorySearcher(deBase);
          dsLookFor.Filter = ou1;
          dsLookFor.SearchScope = SearchScope.Subtree;
          dsLookFor.PropertiesToLoad.Add("ou");
    
          SearchResultCollection srcOUs = dsLookFor.FindAll();
    
          if (srcOUs.Count != 0)
          {
            deList = new List<DirectoryEntry>();
    
            foreach (SearchResult srOU in srcOUs)
            {
              DirectoryEntry deOU = srOU.GetDirectoryEntry();
              if (deOU.Parent.Name.ToUpper() == ou2.ToUpper())
                deList.Add(deOU);
            }
          }
          return deList;
        }
