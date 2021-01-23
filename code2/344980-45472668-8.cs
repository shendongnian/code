	static ulong[] GetEnumValues<T>() where T : struct =>
			(ulong[])typeof(System.Enum)
				.GetMethod("InternalGetValues", BindingFlags.Static | BindingFlags.NonPublic)
				.Invoke(null, new[] { typeof(T) });
	static String[] GetEnumNames<T>() where T : struct =>
			(String[])typeof(System.Enum)
				.GetMethod("InternalGetNames", BindingFlags.Static | BindingFlags.NonPublic)
				.Invoke(null, new[] { typeof(T) });
