    var assemblies = Directory.GetFiles(containingDirectory, "*.dll")'
    foreach (var assembly in assemblies)
    {
        Assembly.Load(AssemblyName.GetAssemblyName(assembly));
    }
