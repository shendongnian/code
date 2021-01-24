    public static List<int> FormObjectIndexExtractor(List<string> values, string prefix, string suffix)
	{
		var s = "^" + prefix + @"(\d+)\.*?" + suffix + "$";
		return values
				.Where(v => Regex.Match(v, s).Success)
				.Select(v=> int.Parse(Regex.Match(v, s).Groups[1].Value))
				.ToList();
	}
