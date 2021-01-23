	public static IEnumerable<string> Uniquifier(this IEnumerable<string> values)
	{
		if (values == null) throw new ArgumentNullException("values");
		var unique = new HashSet<string>();
		foreach(var item in values)
		{
			var newItem = item;
			while(unique.Contains(newItem))
			{
				newItem += '_';
			}
			unique.Add(newItem);
			yield return newItem;
		}
	}
