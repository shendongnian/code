    string input = @"We have 23 students at Cybernetics, 32 students at Computer Science and we also have 12 teachers";
    List<string> keywords = new List<string>();
    keywords.Add("student");
    keywords.Add("teacher");
    keywords.Add("kid");
    keywords.Add("parent");
    foreach(var k in keywords)
    {
        string pattern = @"(\d*) "+k;
        MatchCollection matches = Regex.Matches(input, pattern);
        int total = 0;
        foreach (Match match in matches) {
            total+= Convert.ToInt32(match.Groups[1].Value);
        }
        Console.WriteLine(total + " " + k+", ");
    }
