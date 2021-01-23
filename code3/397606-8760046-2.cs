    string resultString = null;
    try
    {
        string part = "Orlando, Orlando International Airport(MCO), United States";
        resultString = Regex.Match(part, @"(?<=\().*(?=\))", RegexOptions.IgnoreCase | RegexOptions.Multiline).Value;
    }
    catch (ArgumentException ex)
    {
    	// Syntax error in the regular expression
    }
