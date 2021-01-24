    var example = "This is a {match} but this {{is not a match}}.";
	// Match only content from single gullwing braces
	var matches = new System.Text.RegularExpressions.Regex(@"(?<!{){([^}{]+)}(?!})").Matches(example);
		
	// Go through each match and output it
	foreach(System.Text.RegularExpressions.Match match in matches)
	{
        // You only want to grab the content within a given group
		Console.WriteLine(match.Groups[1].Value);
	}
