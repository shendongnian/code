    IEnumerable<SearchResult> Search(string domain, string filter)
    {
        DirectoryContext context = new DirectoryContext(DirectoryContextType.Forest, domain);
        Forest forest = Forest.GetForest(context);
        GlobalCatalog gc = null;
        try
        {
            gc = forest.FindGlobalCatalog();
        }
        catch (ActiveDirectoryObjectNotFoundException)
        {
            // No GC found in this forest
        }
        if (gc != null)
        {
            DirectorySearcher searcher = gc.GetDirectorySearcher();
            searcher.Filter = filter;
            foreach (SearchResult result in searcher.FindAll())
            {
                yield return result;
            }
        }
        else
        {
            foreach (Domain d in forest.Domains)
            {
                DirectorySearcher searcher = new DirectorySearcher(d.GetDirectoryEntry(), filter);
                foreach (SearchResult result in searcher.FindAll())
                    yield return result;
            }
        }
    }
