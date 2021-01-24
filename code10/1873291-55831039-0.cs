    string pattern = @"\{[a-zA-Z\-\s\@\']+\}";
    string input = "{@Charge}; {Current Date} {Current Time}; Scan Operator: {Scan Operator's User ID}; Page: x/y";
    var matches = System.Text.RegularExpressions.Regex.Matches(input, pattern);
    foreach (var match in matches)
    {
    	Console.WriteLine(match);
        // TODO replace
        // var key = match.ToString();
    	// input = input.Replace(key, someMethodToGetValue(key.Replace("{", "").Replace("}", "")));
    }
