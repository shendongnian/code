    static string SplitCapital(string str)
		{
			string[] tmp;
			return SplitCapital(str, out tmp);
		}
		static string SplitCapital(string str, out string[] parts)
		{
			var capLetters = str
				.Select((c, i) => new { c = c, i = i })
				.Where(c => c.i != 0 && Char.IsUpper(c.c));
			if (!capLetters.Any() || capLetters.Count() == str.Length)
			{
				parts = new [] { str };
				return str;
			}
			var lastIndex = 0;
			var result = new List<string>();
			foreach (var cl in capLetters)
			{
				result.Add(str.Substring(lastIndex, cl.i - lastIndex));
				lastIndex = cl.i;
			}
			if (lastIndex != str.Length)
			{
				result.Add(str.Substring(lastIndex));
			}
			parts = result.ToArray();
			return string.Join(" ", parts);
		}
