	public override AssemblyDefinition Resolve(AssemblyNameReference name)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		AssemblyDefinition assemblyDefinition;
		if (this.cache.TryGetValue(name.FullName, out assemblyDefinition))
		{
			return assemblyDefinition;
		}
		assemblyDefinition = base.Resolve(name); // <---------
    // Is the `ReaderParameters` object set by user, used to resolve in `base` class?
    
		this.cache[name.FullName] = assemblyDefinition;
		return assemblyDefinition;
	}
