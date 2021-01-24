    List<Assembly> assemblies = new List<Assembly>();
    string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    foreach (var path in Directory.GetFiles(assemblyFolder, "*.dll"))
    {
        assemblies.Add(Assembly.LoadFrom(path));
    }
