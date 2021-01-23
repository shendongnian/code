	public static object GetDefault(this Type t)
	{	
		if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
		{
			var p = t.GetProperties().Single(a => a.Name == "Value");
			
			t = p.PropertyType;
		}
		
		return t.IsValueType ? Activator.CreateInstance(t) : null;
	}
