	public static object CreateType(string typeName)
	{
		var allTypes = AppDomain.CurrentDomain
			.GetAssemblies()
			.SelectMany
			(
				a => a.GetTypes()
			);
		var type = allTypes.Single( t => t.Name == typeName );
		
		return Activator.CreateInstance(type);
	}
