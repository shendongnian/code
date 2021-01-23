	public static Object TryGetPropertyValue(Object fromThis, String propertyName, Boolean isStatic)
	{
		// Get Type
		Type baseType = fromThis.GetType();
		
		// Get additional binding flags
		BindingFlags addFlag = BindingFlags.Instance;
		if(isStatic)
			addFlag = BindingFlags.Static;
		
		// Get PropertyInfo
		PropertyInfo info = baseType.GetProperty(propertyName, BindingFlags.Public | addFlag);
		
		// Check if we found the Property and if we can read it
		if(info == null && info.CanRead)
				return null;
		
		// Return the value
		return info.GetValue(fromThis, null);
	}
