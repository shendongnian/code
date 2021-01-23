    Regex r = new Regex(@"(?<function>\w[\w\d]*?)\((?<inner>.*?)\)");
    Regex inner = new Regex(@",?(?<param>.+?):""(?<value>[^""]*?)""");
    string input = "_test0(a:\"lolololol\",b:\"2\") _test1(ghgasghe:\"asjkdgh\")";
    List<List<string>> matches = new List<List<string>>();
         
    MatchCollection mc = r.Matches(input);
    foreach (Match match in mc)
    {
        var l = new List<string>();
        l.Add(match.Groups["function"].Value);
        foreach (Match m in inner.Matches(match.Groups["inner"].Value))
        {
             l.Add(m.Groups["param"].Value);
             l.Add(m.Groups["value"].Value);
        }
        matches.Add(l);
    }
