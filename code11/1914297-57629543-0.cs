	public object GetInstance(Type type)
	{
		if (_registeredTypes.ContainsKey(type))
		{
			return _registeredTypes[type]();
		}
		else
		{
			return null; // or throw an exception, etc.
		}
	}
	public object CreateInstance(Type type)
	{
		var constructor = type.GetConstructors().OrderByDescending(c => c.GetParameters().Length).First();
		var args = constructor.GetParameters().Select(p => GetInstance(p.ParameterType)).ToArray();
		return Activator.CreateInstance(type, args);
	}
