    Dictionary<string, int> ExtensionCount = new Dictionary<string, int>();
    foreach (var file in files)
    {
        var ext = Path.GetExtension(file);
        if (ExtensionCount.ContainsKey(ext))
        {
            ExtensionCount[ext]++;
        }
        else
        {
            ExtensionCount.Add(ext, 1);
        }
    }
