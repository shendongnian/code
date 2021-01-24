    var entry = searcher.FindAll()
        .Select(x => (DirectoryEntry)x.GetUnderlyingObject())
        .Where(x => x.Properties["Company"].Value?.ToString() == "My Company")
        .FirstOrDefault();  // or .ToList() depending on your requirements
    if (entry != null)
    {
        // do some stuff
    }
