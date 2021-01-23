	public string[] StringToArray(string input) {
		var pattern = new Regex(@"
			\[
				(?:
				\s*
					(?<results>(?:
					(?(open)  [^\[\]]+  |  [^\[\],]+  )
					|(?<open>\[)
					|(?<-open>\])
					)+)
					(?(open)(?!))
				,?
				)*
			\]
		", RegexOptions.IgnorePatternWhitespace);
		
		// Find the first match:
		var result = pattern.Match(input);
		if (result.Success) {
			// Extract the captured values:
			var captures = result.Groups["results"].Captures.Cast<Capture>().Select(c => c.Value).ToArray();
			return captures;
		}
		// Not a match
		return null;
	}
