	public static List<PropertyInfo> CompareObjects<T>(T o1, T o2, List<PropertyInfo> props) where T : class
	{
		var type = typeof(T);
		var mismatched = CompareObjects(type, o1, o2, props);
		return mismatched;
	}
	
	public static List<PropertyInfo> CompareObjects(Type t, object o1, object o2, List<PropertyInfo> props)
	{
		List<PropertyInfo> mismatched = null;
		foreach (PropertyInfo prop in props)
		{
			if (prop.GetValue(o1, null) == null && prop.GetValue(o2, null) == null) ;
			else if (
				prop.GetValue(o1, null) == null || prop.GetValue(o2, null) == null ||
					!prop.GetValue(o1, null).Equals(prop.GetValue(o2, null)))
			{
				if (mismatched == null) mismatched = new List<PropertyInfo>();
				mismatched.Add(prop);
			}
		}
		return mismatched;
	}
