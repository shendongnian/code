	private static string RemoveQuotes(IEnumerable<char> input)
	{
		string part = new string(input.TakeWhile(c => c != '"' && c != '\'').ToArray());
		var rest = input.SkipWhile(c => c != '"' && c != '\'');
		if(string.IsNullOrEmpty(new string(rest.ToArray())))
			return part;
		char delim = rest.First();
		var afterIgnore = rest.Skip(1).SkipWhile(c => c != delim).Skip(1);
		StringBuilder full = new StringBuilder(part);
		return full.Append(RemoveQuotes(afterIgnore)).ToString();
	}
