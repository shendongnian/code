    Assembly resourceAssembly = Assembly.LoadFrom(resourceFileName);
    string[] manifests = resourceAssembly.GetManifestResourceNames();
    if (manifests.Length == 1)
    {
        string manifest = manifests[0].Replace(".resources", string.Empty);
        manager = new ResourceManager(manifest, resourceAssembly);
    }
    // Works !
    manager.GetString("PleaseCallIT", null);
