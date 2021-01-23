	public static List<KeyValuePair<string, string>> Process(string fileContents)
	{
		const string regexPattern = @"\\(?<filename>[\w\.]+)\(.*HeaderText=""(?<headerText>\w+)""";
			
		var matches = Regex.Matches(fileContents, regexPattern);
		var test = new List<KeyValuePair<string, string>>();
			
		foreach (Match match in matches)
		{
			var fileName = match.Groups["filename"].Value;
			var headerText = match.Groups["headerText"].Value;
			test.Add(new KeyValuePair<string, string>(fileName, headerText));
		}
		return test;
	}
