	/// <summary>
	/// Returns the FieldInfo matching 'name' from either type 't' itself or its most-derived 
    /// base type (unlike 'System.Type.GetField'). Returns null if no match is found.
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
