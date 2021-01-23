    string pattern = Regex.Escape("[") + "(.*?)]";
    string input = "Test [Test2] .. sample text [Test3] ";
    
    MatchCollection matches = Regex.Matches(input, pattern);
    var myResultList = new List<string>();
    foreach (Match match in matches)
    {
        myResultList.Add(match.Value);
    }
