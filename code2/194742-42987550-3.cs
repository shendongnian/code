    private static readonly IReadOnlyCollection<string> LOWER_TRUE_VALUES = new string[] { "true", "t", "1", "yes", "y" };
    public static bool IsTrue(string value)
    {
        return value != null
            ? LOWER_TRUE_VALUES.Contains(value.Trim().ToLower())
            : false;
    }
