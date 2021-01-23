	/// </summary>
	/// <param name="input">The text to perform the replacement upon</param>
	/// <param name="pattern">The regex used to perform the match</param>
	/// <param name="fnReplace">A delegate that selects the appropriate replacement text</param>
	/// <returns>The newly formed text after all replacements are made</returns>
	public static string Transform(string input, Regex pattern, Converter<Match, string> fnReplace)
	{
		int currIx = 0;
		StringBuilder sb = new StringBuilder();
		foreach (Match match in pattern.Matches(input))
		{
			sb.Append(input, currIx, match.Index - currIx);
			string replace = fnReplace(match);
			sb.Append(replace);
			currIx = match.Index + match.Length;
		}
		sb.Append(input, currIx, input.Length - currIx);
		return sb.ToString();
	}
