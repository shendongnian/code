		string firstString = "aaaa 12312 <asdad> 12334 </asdad>";
		Regex firstRegex = new Regex(@"(?<Digits>[\d]+)", RegexOptions.ExplicitCapture);
		if (firstRegex.IsMatch(firstString))
		{
			MatchCollection firstMatches = firstRegex.Matches(firstString);
			foreach (Match match in firstMatches)
			{
				Console.WriteLine("Digits: " + match.Groups["Digits"].Value);
			}
		}
		
		string secondString = "aaaa 1234 ...... 1234 ::::: asgsgd";
		Regex secondRegex = new Regex(@"([\.]+\s(?<Digits>[\d]+))|([\:]+\s(?<Words>[a-zA-Z]+))", RegexOptions.ExplicitCapture);
		if (secondRegex.IsMatch(secondString))
		{
			MatchCollection secondMatches = secondRegex.Matches(secondString);
			foreach (Match match in secondMatches)
			{
				if (match.Groups["Digits"].Success)
				{
					Console.WriteLine("Digits: " + match.Groups["Digits"].Value);
				}
				if (match.Groups["Words"].Success)
				{
					Console.WriteLine("Words: " + match.Groups["Words"].Value);
				}
			}
		}
