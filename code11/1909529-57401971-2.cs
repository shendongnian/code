    var files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
    var groups = files.GroupBy(x => Path.GetExtension(x));
    Dictionary<string, int> ExtensionCount = new Dictionary<string, int>();
    foreach(var group in groups)
    {
        ExtensionCount.Add(group.Key, group.Count());
    }
