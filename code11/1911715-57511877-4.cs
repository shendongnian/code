    public static List<int> FormObjectIndexExtractor(List<string> values, string prefix, string suffix)
	{
		List<int> ret = new List<int>();
		Regex r = new Regex($"^{prefix}(\d+){suffix}$");
		foreach (var s in values)
		{
			var match = r.Match(s);
			if (match.Success)
			{
				ret.Add(int.Parse(match.Groups[1].ToString()));
			}
		}
		return ret;
	}
