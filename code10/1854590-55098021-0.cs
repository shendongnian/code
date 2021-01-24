    public static void LoadAllLocalAssemblies()
    {
        var entryAssembly = Assembly.GetEntryAssembly();
        var location = entryAssembly.Location;
        var path = Path.GetDirectoryName(location);
        var files = Directory.EnumerateFiles(path, "*.dll");
        foreach (var file in files)
        {
            try
            {
                Assembly.LoadFrom(file);
            }
            catch
            {
            }
        }
    }
