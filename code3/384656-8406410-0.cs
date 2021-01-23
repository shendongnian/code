	Dictionary<string, int> dictionary = new Dictionary<string, int>();
	string delimitedTags = "some tab delimited string";
	List<string> tags = delimitedTags.Split(new char[] {'\t'}, StringSplitOptions.None).ToList();
	foreach (string tag in tags.Distinct())
	{
		dictionary.Add(tag, tags.Where(t => t == tag).Count());
	}
