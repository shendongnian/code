		// Handle generic types
		if (type.IsGenericType)
		{
			string name = type.Name.Split('`').FirstOrDefault();
			IEnumerable<string> parms = 
				type.GetGenericArguments()
				.Select(a => type.IsConstructedGenericType ? TypeNameOrAlias(a) : a.Name);
			return $"{name}<{string.Join(",", parms)}>";
		}
