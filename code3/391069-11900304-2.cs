	/// <summary>
	/// Creates an List with all keys and values of a given Enum class
	/// </summary>
	/// <typeparam name="T">Must be derived from class Enum!</typeparam>
	/// <returns>A list of KeyValuePair&lt;Enum, string&gt; with all available
	/// names and values of the given Enum.</returns>
	public static IList<KeyValuePair<T, string>> ToList<T>() where T : struct
	{
		var type = typeof(T);
		if (!type.IsEnum)
		{
			throw new ArgumentException("T must be an enum");
		}
		return (IList<KeyValuePair<T, string>>)
				Enum.GetValues(type)
					.OfType<T>()
					.Select(e =>
					{
						var asEnum = (Enum)Convert.ChangeType(e, typeof(Enum));
						return new KeyValuePair<T, string>(e, asEnum.Description());
					})
					.ToArray();
	}
