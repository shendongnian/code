	private static IReadOnlyList<Weight> ExtractWeights(Type type)
	{
		return type
			.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
			.Select(x => x.GetCustomAttribute<WeightAttribute>()?.Weight)
			.Where(x => x!= null)
			.ToArray();
	}
