	public static object GetDefault(this Type type)
	{	
		if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
		{
			var valueProperty = type.GetProperty("Value");
			type = valueProperty.PropertyType;
		}
		
		return type.IsValueType ? Activator.CreateInstance(type) : null;
	}
