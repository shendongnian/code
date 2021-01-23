	public static T ToEnum<T>(this string s) {
		if (string.IsNullOrWhiteSpace(s))
			return default(T);
		s = s.Replace(" ", "");
		if (typeof(T).BaseType.FullName != "System.Enum" &&
			typeof(T).BaseType.FullName != "System.ValueType") {
			throw new ArgumentException("Type must be of Enum and not " + typeof(T).BaseType.FullName);
		}
		if (typeof(T).BaseType.FullName == "System.ValueType")
			return (T)Enum.Parse(Nullable.GetUnderlyingType(typeof(T)), s, true);
		return (T)Enum.Parse(typeof(T), s, true);
	}
