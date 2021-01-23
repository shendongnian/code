    public IEnumerable<ScanItem> Search(IEnumerable<ScanItem> allItems, 
        string nameContains)
    {
        foreach (var item in allItems)
        {
            if (item.IsDirectory)
                foreach (var child in Search(((ScanDir)item).Items, nameContains))
                    yield return child;
            else if (item.Name.Contains(nameContains))
                yield return item;
        }
    }
