	IEnumerable<string> Subsequences(string input)
	{
		return
			Enumerable
				.Range(0, input.Length)
				.SelectMany(x =>
					Enumerable
						.Range(1, input.Length - x),
					(x, y) => input.Substring(x, y));
	}
