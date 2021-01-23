	static Regex SpaceTrimmer = new Regex(@"\s+");
	static readonly Regex CamelCaseSplitter = new Regex(@"_|(?<![A-Z])(?=[A-Z]+)|(?<=[A-Z])(?=[A-Z][^A-Z_])");
	public static string SplitWords(this string name) {
		if (name == null) return null;
		return SpaceTrimmer.Replace(String.Join(" ",
			CamelCaseSplitter.Split(name)
							 .Select(s => s.Any(Char.IsLower) ? s.ToLower(CultureInfo.CurrentCulture) : s)
		), " ").Trim();
	}
