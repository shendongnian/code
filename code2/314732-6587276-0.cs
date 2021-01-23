    public IEnumerable<ScanItem> GetItems(IEnumerable<ScanItem> allItems)
    {
        foreach (var item in allItems)
        {
            if (!item.IsDirectory)
                yield return item;
            else
                foreach (var child in GetItems(item.Items))
                    yield return child;
        }
    }
    // ...
    return GetItems(allItems).Where(i => i.Name.Contains("foo"));
