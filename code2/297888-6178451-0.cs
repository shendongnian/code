	var type = c.GetType();
	Type baseType = type;
	while(null != (baseType = baseType.BaseType)) 
	{
		if (baseType.IsGenericType) 
		{
			var generic = baseType.GetGenericTypeDefinition();
			if (generic == typeof(MyBase<,>)) 
			{
				var genericTypes = baseType.GetGenericArguments();
				// genericTypes has the type argument used to construct baseType.
				break;
			}
		}
	}	
