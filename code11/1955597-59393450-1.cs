    public static string FindWord2InLine(string line, string punctuation)
    {
        var matches = Regex.Matches(line, $"\\w+[{punctuation}]");  //match word with punctuation after it
        string temp = "";
        foreach (var match in matches)
        {
            temp += match;  // perform action with word and punctuation
        }
        return temp;
    }
