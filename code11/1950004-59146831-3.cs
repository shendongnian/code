	static T Parse<T>(string s)
	{
		T result;
		if (typeof(T).IsArray)
		{
			var TE = typeof(T).GetElementType();
			MethodInfo method = typeof(Program).GetMethod("ParseArray", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
			MethodInfo generic = method.MakeGenericMethod(TE);
			result = (T)generic.Invoke(null, new object[] { s });
		}
		else
		{
			result = (T)Convert.ChangeType(s, typeof(T), CultureInfo.InvariantCulture);
		}
		return result;
	}
