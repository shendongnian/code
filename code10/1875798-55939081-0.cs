	protected const string ValidUserNameCharacters = @"\p{L}\w.!_-";
	public const string ValidUserNamePattern = @"^(?=.{5,53}$)([" + ValidUserNameCharacters + @"]?)*$";
	public const string InvalidUserNamePattern = @"([^" + ValidUserNameCharacters + "])";
	
	var invalidString = "Te st|^us r";
	var validUserNameRegEx = new Regex(OpManConstants.ValidUserNamePattern, RegexOptions.Compiled);
	var invalidUserNameRegEx = new Regex(OpManConstants.InvalidUserNamePattern, RegexOptions.Compiled);
	if (!validUserNameRegEx.IsMatch(invalidString))
	{
		var matches = invalidUserNameRegEx.Matches(invalidString);
		var builder = new StringBuilder();
		foreach (var match in matches.Cast<Match>())
		{
			builder.AppendLine("'" + match.Groups[0] + "' at char " + (match.Index + 1));
		}
		Console.WriteLine(builder.ToString());
	}
