    Regex r = new Regex(@"(?<function>[\p{L}_]\w*?)\((?<inner>.*?)\)");
    Regex inner = new Regex(@",?(?<param>.+?):""(?<value>[^""]*?)""");
    string input = "_test0(a:\"lolololol\",b:\"2\") _test1(ghgasghe:\"asjkdgh\")";
    var matches = new List<FunctionInfo>();
    if (r.IsMatch(input))
    {
        MatchCollection mc = r.Matches(input);
        foreach (Match match in mc)
        {
            var l = new List<ParamValue>();
            foreach (Match m in inner.Matches(match.Groups["inner"].Value))
                l.Add(new ParamValue
                {
                    Parameter = m.Groups["param"].Value,
                    Value = m.Groups["value"].Value
                });
            matches.Add(new FunctionInfo
            {
                FunctionName = match.Groups["function"].Value,
                Values = l
            });
        }
    }
