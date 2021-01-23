    string pattern = "car";
    Regex rx = new Regex(pattern, RegexOptions.None);
    MatchCollection mc = rx.Matches(inputText);
    foreach (Match m in mc)
    {
        Console.WriteLine(m.Value);
    }
