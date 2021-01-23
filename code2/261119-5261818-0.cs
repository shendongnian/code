    string pattern = "\\s(\\S+)\\s*=\"([^\"]+)";
    MatchCollection matches = Regex.Matches(inputString, pattern);
    foreach(Match m in matches)
    {
        Console.WriteLine(m.Groups[1].Value); // attrib name
        Console.WriteLine(m.Groups[2].Value); // attrib value
    }
