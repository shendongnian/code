    object CallMethodReflection(object o, string nameMethod, params object[] args)
    {
    	try
    	{
    		var types = TypesFromObjects(args);
    		var theMethod = o.GetType().GetMethod(nameMethod, CustomBinder.Flags, new CustomBinder(), types, null);
    		return (theMethod == null) ? null : theMethod.Invoke(o, args);
    	}
    	catch (Exception ex)
    	{
    		return null;
    	}
    }
    Type[] TypesFromObjects(params object[] pParams)
    {
    	var types = new List<Type>();
    	foreach (var param in pParams)
    	{
    		types.Add((param == null) ? typeof(void) : param.GetType()); // GetMethod above doesn't like a simply null value for the type
    	}
    	return types.ToArray();
    }
    private class CustomBinder : Binder
    {
    	public const BindingFlags Flags = BindingFlags.Public | BindingFlags.Instance;
    	public override MethodBase SelectMethod(BindingFlags bindingAttr, MethodBase[] matches, Type[] types, ParameterModifier[] modifiers)
    	{
    		if (matches == null)
    			throw new ArgumentNullException("matches");
    		foreach (var match in matches)
    		{
    			if (MethodMatches(match.GetParameters(), types, modifiers))
    				return match;
    		}
    		return Type.DefaultBinder.SelectMethod(bindingAttr, matches, types, modifiers); // No matches. Fall back to default
    	}
    	private static bool MethodMatches(ParameterInfo[] parameters, Type[] types, ParameterModifier[] modifiers)
    	{
    		if (types.Length != parameters.Length)
    			return false;
    		for (int i = types.Length - 1; i >= 0; i--)
    		{
    			if ((types[i] == null) || (types[i] == typeof(void)))
    			{
    				if (parameters[i].ParameterType.IsValueType)
    					return false; // We don't want to chance it with a wonky value
    			}
    			else if (!parameters[i].ParameterType.IsAssignableFrom(types[i]))
    			{
    				return false; // If any parameter doesn't match, then the method doesn't match
    			}
    		}
    		return true;
    	}
    }
