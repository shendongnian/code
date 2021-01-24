		string input = "<body style=\"someAttr\"><tag>sdsdsa</tag></body>";
		Regex Pattern = new Regex(@"(<body.*?>)(.*?)(<\/body>)", RegexOptions.Compiled);
		
		var updatedText = Pattern.Replace(input, match =>
    	{
        	string newMatch = match.Groups[2].Value;
			string newContent = "<div>" + "someStringWithAdditionalContent" + "</div>";
			return match.Groups[1].Value + newContent + newMatch + match.Groups[3].Value;
	    });
		Console.WriteLine(updatedText);
