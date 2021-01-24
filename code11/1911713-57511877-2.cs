    public static List<int> FormObjectIndexExtractor(List<string> values, string prefix, string suffix)
	{
		List<int> ret = new List<int>();
		Regex r = new Regex("^([a-zA-Z]+)(\\d+)([a-zA-Z]+)$");
		foreach (var s in values)
		{
			var match = r.Match(s);
			if (match.Success)
			{
				if (match.Groups[1].ToString() == prefix && match.Groups[3].ToString() == suffix)
				{
					ret.Add(int.Parse(match.Groups[2].ToString()));
				}
			}
		}
		return ret;
	}
