	public static IEnumerable<TTo> CopyList<TTo>(
		IEnumerable<object> from,
		Dictionary<Type, Type> typeMap
	)
		where TTo : new()
	{
