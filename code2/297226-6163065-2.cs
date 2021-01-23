    String input = @"name, catg, {y:2006, v:1000, c:100, vt:1}, {y:2007, v:1000, c:100, vt:1}";
    String pattern =
          @"(?'name'\w+), \s*
            (?'category'\w+), \s*
            (?:
                \{ \s*
                    y: (?'y'\d+), \s*
                    v: (?'v'\d+), \s*
                    c: (?'c'\d+), \s*
                    vt: (?'vt'\d+)
                \} \s*
                ,? \s*
            )* ";
    RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline;
    Match match = Regex.Match(input, pattern, options);
    if (match.Success)
    {
        String name = match.Groups["name"].Value;
        String category = match.Groups["category"].Value;
        Console.WriteLine("name = {0}, category = {1}", name, category);
        for (Int32 i = 0; i < match.Groups["y"].Captures.Count; ++i)
        {
            Int32 y = Int32.Parse(match.Groups["y"].Captures[i].Value);
            Int32 v = Int32.Parse(match.Groups["v"].Captures[i].Value);
            Int32 c = Int32.Parse(match.Groups["c"].Captures[i].Value);
            Int32 vt = Int32.Parse(match.Groups["vt"].Captures[i].Value);
            Console.WriteLine("y = {0}, v = {1}, c = {2}, vt = {3}", y, v, c, vt);
        }
    }
