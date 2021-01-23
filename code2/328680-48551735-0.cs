	/// <summary>
	/// Includes private fields in base classes of 't' (unlike 'System.Type.GetField')
	/// </summary>
	public static FieldInfo GetPrivateField(this Type t, String name)
	{
		FieldInfo fi;
		do
			if ((fi = t.GetField(name, BindingFlags.Instance | 
									   BindingFlags.NonPublic | 
									   BindingFlags.DeclaredOnly)) != null)
				return fi;
		while ((t = t.BaseType) != null);
		return null;
	}
