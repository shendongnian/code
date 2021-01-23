    var regex = new Regex(@"Start Section \d+ - (?<section>\w+)\r\n(?<list>[\w\s]+)End Section", RegexOptions.IgnoreCase);
    
    var data = new Dictionary<string, List<string>>();
    
    foreach (Match match in regex.Matches(File.ReadAllText("types.txt")))
    {
        string section = match.Groups["section"].Value;
        string[] items = match.Groups["list"].Value.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    
        data.Add(section, new List<string>(items));
    }
    // data["animals"] now contains a list of "dog", "cat", "horse", and "cow"
