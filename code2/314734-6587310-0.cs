    public List<ScanItem> Search(List<ScanItem> scanItems)
    {
        List<ScanItem> results = scanItems.Where( x => x.IsDirectory)
                                          .Select( x => Search( new List<ScanItem>() { x }))
                                          .SelectMany( s => s)
                                          .ToList();
        results.AddRange(scanItems.Where( x => !x.IsDirectory &&
                                                x.Name.Contains("Foo")));
        return results;
    }
