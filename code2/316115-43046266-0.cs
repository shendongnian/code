	static Assembly LoadAssembly(string assemblyPath)
	{
		// If the target assembly is already loaded, return the existing assembly instance.
		Assembly[] loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
		Assembly targetAssembly = loadedAssemblies.FirstOrDefault((x) => !x.IsDynamic && String.Equals(x.Location, assemblyPath, StringComparison.OrdinalIgnoreCase));
		if (targetAssembly != null)
		{
			return targetAssembly;
		}
		// Attempt to load the target assembly
		return Assembly.LoadFile(assemblyPath);
	}
