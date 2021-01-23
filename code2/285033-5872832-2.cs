    public static string[] GetResourcesUnder(string folder)
    {
        folder = folder.ToLower() + "/";
    
        var assembly       = Assembly.GetCallingAssembly();
        var resourcesName  = assembly.GetName().Name + ".g.resources";
        var stream         = assembly.GetManifestResourceStream(resourcesName);
        var resourceReader = new ResourceReader(stream);
    
        var resources =
            from p in resourceReader.OfType<DictionaryEntry>()
            let theme = (string)p.Key
            where theme.StartsWith(folder)
            select theme.Substring(folder.Length);
    
        return resources.ToArray();
    }
