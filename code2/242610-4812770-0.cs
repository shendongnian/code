    IEnumerable<DirectoryEntry> FindUsers(DirectoryEntry root)
    {
        using (DirectorySearcher searcher = new DirectorySearcher(root))
        {
            searcher.Filter = "(&(objectClass=user)(objectCategory=person))";
            searcher.SearchScope = SearchScope.OneLevel;
            searcher.PageSize = 1000;
            foreach (SearchResult result in searcher.FindAll())
            {
                yield return result.GetDirectoryEntry();
            }
        }
    }
