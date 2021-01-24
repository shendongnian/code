    public static IEnumerable<IEnumerable<string>> ParseSourceToEnumerables(string source)
    {
        var matches = Regex.Matches(source, @"\[(.*?)\]", RegexOptions.Singleline);
        int previousIndex = 0;
        foreach (Match match in matches)
        {
            var previousLiteral = source.Substring(
                previousIndex, match.Index - previousIndex);
            if (previousLiteral.Length > 0)
                yield return Enumerable.Repeat(previousLiteral, 1);
            yield return SinglePatternToEnumerable(match.Groups[1].Value);
            previousIndex = match.Index + match.Length;
        }
        var lastLiteral = source.Substring(previousIndex, source.Length - previousIndex);
        if (lastLiteral.Length > 0) yield return Enumerable.Repeat(lastLiteral, 1);
    }
    public static IEnumerable<string> SinglePatternToEnumerable(string pattern)
    {
        // TODO
        // Should transform the pattern "X,A-C,YZ"
        // to the sequence ["X", "A", "B", "C", "YZ"]
    }
