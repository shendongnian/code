    public static string ReplaceWithIncrementedNumber(Match match)
    {
        Debug.Assert(match.Success);
        var number = Int32.Parse(match.Groups["Number"].Value);
        return String.Format("{0}-{1}-{2}", match.Groups["Category"].Value, match.Groups["Code"].Value, number + 1);
    }
