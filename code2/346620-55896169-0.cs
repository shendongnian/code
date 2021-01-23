	/// <summary>
	/// Returns a copy of the original string containing only the set of whitelisted characters.
	/// </summary>
	/// <param name="value">The string that will be copied and scrubbed.</param>
	/// <param name="alphas">If true, all alphabetical characters (a-zA-Z) will be preserved; otherwise, they will be removed.</param>
	/// <param name="numerics">If true, all alphabetical characters (a-zA-Z) will be preserved; otherwise, they will be removed.</param>
	/// <param name="dashes">If true, all alphabetical characters (a-zA-Z) will be preserved; otherwise, they will be removed.</param>
	/// <param name="underlines">If true, all alphabetical characters (a-zA-Z) will be preserved; otherwise, they will be removed.</param>
	/// <param name="spaces">If true, all alphabetical characters (a-zA-Z) will be preserved; otherwise, they will be removed.</param>
	/// <param name="periods">If true, all decimal characters (".") will be preserved; otherwise, they will be removed.</param>
	public static string RemoveExcept(string value, bool alphas = false, bool numerics = false, bool dashes = false, bool underlines = false, bool spaces = false, bool periods = false) {
		if (string.IsNullOrWhiteSpace(value)) return value;
		if (new[] { alphas, numerics, dashes, underlines, spaces, periods }.All(x => x == false)) return value;
 
		var whitelistChars = new HashSet<char>(string.Concat(
			alphas ? "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" : "",
			numerics ? "01234567890" : "",
			dashes ? "-" : "",
			underlines ? "_" : "",
			periods ? "." : "",
			spaces ? " " : ""
		).ToCharArray());
 
		var scrubbedValue = value.Aggregate(new StringBuilder(), (sb, @char) => {
			if (whitelistChars.Contains(@char)) sb.Append(@char);
			return sb;
		}).ToString();
 
		return scrubbedValue;
	}
