    MatchCollection allMatchResults = null;
    try {
        // This matches a literal '=' and then any number of digits following
    	Regex regexObj = new Regex(@"=(\d+)");
    	allMatchResults = regexObj.Matches(subjectString);
    	if (allMatchResults.Count > 0) {
    		// Access individual matches using allMatchResults.Item[]
    	} else {
    		// Match attempt failed
    	} 
    } catch (ArgumentException ex) {
    	// Syntax error in the regular expression
    }
