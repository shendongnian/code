	public static Dictionary<int, string> EnumDictionary<T>()
	{
		if (!typeof(T).IsEnum)
			throw new ArgumentException("Type must be an enum");
		return Enum.GetValues(typeof(T))
			.Cast<T>()
			.ToDictionary(t => (int)(object)t, t => t.ToString());
	}
