	/// <summary>
	/// Returns the FieldInfo matching 'name' from either type 't' itself or its most-derived 
    /// base type (unlike 'System.Type.GetField'). Returns null if no match is found.
	/// </summary>
	public static FieldInfo GetPrivateField(this Type t, String name)
	{
		const BindingFlags bf = BindingFlags.Instance | 
								BindingFlags.NonPublic | 
								BindingFlags.DeclaredOnly;
		FieldInfo fi;
		while ((fi = t.GetField(name, bf)) == null && (t = t.BaseType) is Type)
			;
		return fi;
	}
