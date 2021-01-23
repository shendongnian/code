    // get cultures for a specific resource info
    public static IEnumerable<CultureInfo> EnumSatelliteLanguages(string baseName)
    {
        if (baseName == null)
            throw new ArgumentNullException("baseName");
        ResourceManager manager = new ResourceManager(baseName, Assembly.GetExecutingAssembly());
        ResourceSet set = manager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
        if (set != null)
            yield return CultureInfo.InvariantCulture;
        
        foreach (CultureInfo culture in EnumSatelliteLanguages())
        {
            set = manager.GetResourceSet(culture, true, false);
            if (set != null)
                yield return culture;
        }
    }
    // determine what assemblies are available
    public static IEnumerable<CultureInfo> EnumSatelliteLanguages()
    {
        foreach (string directory in Directory.GetDirectories(AppDomain.CurrentDomain.BaseDirectory))
        {
            string name = Path.GetFileNameWithoutExtension(directory); // resource dir don't have an extension...
            // format is XX-YY, we discard directories that can't match.
            // could/should be replaced by a regex but we still need to catch cultures errors...
            if (name.Length > 5)
                continue;
            CultureInfo culture = null;
            try
            {
                culture = CultureInfo.GetCultureInfo(name);
            }
            catch
            {
                // not a good directory...
                continue;
            }
            string resName = Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location) + ".resources.dll";
            if (File.Exists(Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, name), resName)))
                yield return culture;
        }
    }
