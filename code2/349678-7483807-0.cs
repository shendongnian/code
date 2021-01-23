    var results = new List<string>();
    var subjectString = "My Name is #P_NAME# and \r\n I am #P_AGE# years old";
    Regex regexObj = new Regex("#.+?#", RegexOptions.IgnoreCase | RegexOptions.Multiline);
    Match matchResults = regexObj.Match(subjectString);
    while (matchResults.Success) {
    	results.Add(matchResults.ToString().Replace("#",""));
    	matchResults = matchResults.NextMatch();
    }
