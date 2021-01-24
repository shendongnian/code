	public static IEnumerable<string> GetDiffPaths(this JContainer root)
	{
		if (root == null)
			throw new ArgumentNullException(nameof(root));
		var query = from array in root.DescendantsAndSelf().OfType<JArray>()
					where array.Count == 2 && array[0] is JValue && array[1] is JValue
					select $"{array.Path}/new:{array[0]}/old:{array[1]}";
		return query;
	}
