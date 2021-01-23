    	public static bool IsNullOrDefault<T>(T argument)
	{
		if (argument is ValueType || argument != null)
		{
			return object.Equals(argument, GetDefault(argument.GetType()));
		}
		return true;
	}
	
	
	public static object GetDefault(Type type)
	{
		if(type.IsValueType)
		{
			return Activator.CreateInstance(type);
		}
		return null;
	}
