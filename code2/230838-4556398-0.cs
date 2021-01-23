    public static IEnumerable<string> SplitOnLength(this string s, int length)
    {
        var pattern = @"^.{0," + length + @"}\W";
        var result = Regex.Match(s, pattern).Groups[0].Value;
        if (result == string.Empty)
        {
            if (s == string.Empty) yield break;
            result = s.Substring(0, length);
        }
        yield return result;
        foreach (var subsequent_result in SplitOnLength(s.Substring(result.Length), length))
        {
            yield return subsequent_result;
        }
    }
