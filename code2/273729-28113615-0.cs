	public static Dictionary<int, string> EnumDictionary<T>()
	{
		if (!typeof(T).IsEnum)
			throw new ArgumentException("Type must be an enum");
		return Enum.GetValues(typeof(T))
			.Cast<T>()
			.ToDictionary(t => 
			   (int)Convert.ChangeType(t, t.GetType()), 
			   t => t.ToString()
			);
	}
