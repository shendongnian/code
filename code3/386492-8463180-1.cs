    string url = "member/filter-three/option/option";
    url = url.Replace("member/filter-", string.Empty); // cutting static content
    MatchCollection matches = new Regex(@"([^/]+)/?").Matches(url);
    foreach (Match match in matches)
    {
        Console.WriteLine(match.Groups[1].Value);
    }
    Console.ReadLine();
