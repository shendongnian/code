    Regex pattern = new Regex("([0-9]*)$");
    MatchCollection matches = pattern.Matches(input);
    if (matches.Count > 0) {
        // matches[0] will contain the number
    }
    
