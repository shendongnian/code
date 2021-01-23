    // Define a test string.
    string text = "Hello stackoverflow world";
    
    string like = "%flow%";
    
    // Define a regular expression and Find matches.
    MatchCollection matches = LikeExpressionToRegexPattern(like).Matches(text);
    
    //Result.
    if (matches.Count > 0) {
    	//Yes
    } else {
    	//No
    }
