    string pattern = "car";
    Regex rx = new Regex(pattern, RegexOptions);
    MatchCollection mc = rx.Matches(inputText);
    foreach (Match m in mc)
    {
        Console.WriteLine(m.Value);
    }
