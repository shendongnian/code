	Regex regexObj = new Regex(@"(?<="")\b[a-z,]+\b(?="")|[a-z]+", RegexOptions.IgnoreCase);
	allMatchResults = regexObj.Matches(subjectString);
	if (allMatchResults.Count > 0) {
		// Access individual matches using allMatchResults.Item[]
	}
