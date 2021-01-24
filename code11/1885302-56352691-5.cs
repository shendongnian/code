	static string GetTypeName(Type type)
	{
		string name = TypeNameOrAlias(type);
		if (type.DeclaringType is Type dec)
		{
			return $"{GetTypeName(dec)}.{name}";
		}
		return name;
	}
	// GetTypeName(typeof(Outer.Inner)) == "Outer.Inner"
