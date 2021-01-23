	public static bool DoesTypeSupportInterface(Type type, Type inter)
	{
		if(inter.IsAssignableFrom(type))
			return true;
		if(type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == inter))
			return true;
		return false;
	}
    public static IEnumerable<Type> TypesImplementingInterface(Type desiredType)
	{
		return AppDomain
			.CurrentDomain
			.GetAssemblies()
			.SelectMany(assembly => assembly.GetTypes())
			.Where(type => DoesTypeSupportInterface(type, desiredType));
	}
