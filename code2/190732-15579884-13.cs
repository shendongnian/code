	public static Type GetIEnumerableType(Type type)
	{
		var ienumerable = type.GetInterface(typeof(System.Collections.Generic.IEnumerable<>).FullName);
		var generics = ienumerable.GetGenericArguments();
		return generics[0];
	}
