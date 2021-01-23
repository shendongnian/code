    IEnumerable<string> GetAssemblyFiles(Assembly assembly)
    {
        var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
		foreach (var assemblyName in assembly.GetReferencedAssemblies())
			yield return loadedAssemblies.SingleOrDefault(a => a.FullName == assemblyName.FullName)?.Location;
    }
