    var entry = searcher.FindAll()
        .Select(x => (DirectoryEntry)x.GetUnderlyingObject())
        .Where(x => x.Properties["Company"].Value?.ToString() == "My Company")
        .FirstOrDefault();
    if (entry != null)
    {
        // do some stuff
    }
