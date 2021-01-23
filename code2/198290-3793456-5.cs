    private static readonly Regex rx = new Regex
        (@"<file>(.+?)</file>", RegexOptions.IgnoreCase);
     
    static void Extract(string text)
    {
        MatchCollection matches = rx.Matches(text);
     
        foreach (Match match in matches)
        {
            Console.WriteLine("'{0}'", match.Groups[1]);
        }
    }
