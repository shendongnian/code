    IEnumerable<DirectoryEntry> FindUserParentObject(DirectoryEntry root)
    {
        using (DirectorySearcher searcher = new DirectorySearcher(root))
        {
            searcher.Filter = "(|(objectClass=organizationalUnit)(objectClass=container)(objectClass=builtinDomain)(objectClass=domainDNS))";
            searcher.SearchScope = SearchScope.Subtree;
            searcher.PageSize = 1000;
            foreach (SearchResult result in searcher.FindAll())
            {
                yield return result.GetDirectoryEntry();
            }
        }
    }
