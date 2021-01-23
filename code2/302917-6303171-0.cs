    private static readonly Regex GuidPattern = new Regex
        ("^[0-9A-F]{8}-[0-9A-F]{4}-[0-9A-F]{4}-[0-9A-F]{4}-[0-9A-F]{12}$",
          RegexOptions.Compiled);
    public static bool IsValidRegex(string inputString)
    {
        return GuidPattern.IsMatch(inputString);
    }
