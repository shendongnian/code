    string pattern = @"\< *CHOICE *((\[(?<choice>[a-zA-Z0-9 ]+)\]) *)+ *>";
    Regex regex = new Regex(pattern);
    string source = "I like <CHOICE [cars and bikes] [apple and oranges]>";
            
    var match = regex.Match(source);
    if (match.Success)
    {
        for (int i = 0; i < match.Groups["choice"].Captures.Count; i++)
        {
            Debug.WriteLine(match.Groups["choice"].Captures[i]);
        }
        string replaced = regex.Replace(source, match.Groups["choice"].Captures[0].Value);
        Debug.WriteLine(replaced);
    }
