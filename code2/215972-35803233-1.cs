    IEnumerable<string> GetAssemblyFiles(Assembly assembly)
    {
        var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
        return assembly.GetReferencedAssemblies()
            .Select(name => loadedAssemblies.SingleOrDefault(a => a.FullName == name.FullName)?.Location)
            .Where(l => l != null);
    }
