    string input = "12345";
    string pattern = @"\d{4}";
    var matches = new List<Match>();
    var hadMatch = true;
    for (var i = 0; hadMatch; i++)
    {
        var theString = input.Skip(i)
            .Aggregate(new StringBuilder(), (sb, c) => sb.Append(c))
            .ToString();
        var oldCount = matches.Count;
        matches.AddRange(Regex.Matches(theString, pattern)
                             .OfType<Match>()
                             .Where(m => !matches.Any(m2 => m.Value == m2.Value)));
        hadMatch = oldCount != matches.Count;
    }
