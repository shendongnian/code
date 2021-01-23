    public static MethodInfo GetGenericMethod(Type declaringType, string methodName, Type[] typeArgs, params Type[] argTypes) {
    	foreach (var m in from m in declaringType.GetMethods()
    						where m.Name == methodName
    							&& typeArgs.Length == m.GetGenericArguments().Length
    							&& argTypes.Length == m.GetParameters().Length
    						select m.MakeGenericMethod(typeArgs)) {
    		if (m.GetParameters().Select((p, i) => p.ParameterType == argTypes[i]).All(x => x == true))
    			return m;
    	}
    	
    	return null;
    }
