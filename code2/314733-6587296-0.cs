    private void SearchCore(IEnumerable<ScanItem> items, List<ScanItem> foundItems)
    {
        foreach (ScanItem s in items)
        {
            if (s.IsDirectory)
            {
                foundItems.Add(s);
                searchCore (((ScanDir)s2).Items, foundItems);
            }
            else if (s.Name.Contains("Foo"))                    
                    foundItems.Add(s);
        }
    }
    public List<ScanItem> Search(List<ScanItem> allItems)
    {
        List<ScanItem> foundItems = new List<ScanItem>();
        searchCore (allItems, foundItems);
        return foundItems;
    }
