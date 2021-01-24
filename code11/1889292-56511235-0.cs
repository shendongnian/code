	public static IEnumerable<int> SplitInts(this string source)
	{
		for (var i = 0; i < source.Length; i += 2)
			yield return int.Parse(source.Substring(i, Math.Min(2, source.Length - i)));
	}
