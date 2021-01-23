    Regex r = new Regex(@"(?<function>\w[\w\d]*?)\((?<param>.+?):""(?<value>.*?)""");
    string input = "_test0(aa%£$!:\"lolololol\") _test1(ghgasghe:\"asjkdgh\")";
    List<string[]> matches = new List<string[]>();
    if(r.IsMatch(input))
    {
        MatchCollection mc = r.Matches(input);
        foreach (Match match in mc)
        matches.Add(new[] { match.Groups["function"].Value, match.Groups["param"].Value, match.Groups["value"].Value });
    }
