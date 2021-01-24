    var grid = <FindGrid>.AsGrid();
    var cacheRequest = new CacheRequest();
    cacheRequest.TreeScope = TreeScope.Descendants;
    cacheRequest.Add(Automation.PropertyLibrary.Element.Name);
    using (cacheRequest.Activate())
    {
        var rows = _grid.Rows;
        foreach (var row in rows)
        {
            foreach (var cell in row.CachedChildren)
            {
                Console.WriteLine(cell.Name);
            }
        }
    }
