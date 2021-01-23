    private static readonly Regex dateRegex = new Regex(@"\d{1,2}/\d{1,2}/\d{4}");
    public static IEnumerable<string> ExtractDates(string str)
    {
        return dateRegex.Matches(str).Cast<Match>().Select(match => match.Value);
    }
