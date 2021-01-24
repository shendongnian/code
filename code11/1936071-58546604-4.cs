    public static bool ContainsWords(string source, string search, 
        List<char> charsToIgnore = null, bool ignoreCase = true)
    {
        var comparer = ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal;
        var sourceWords = GetWords(RemoveChars(source, charsToIgnore));
        var searchWords = GetWords(RemoveChars(search, charsToIgnore));
        return searchWords.All(searchWord => sourceWords.Contains(searchWord, comparer));
    }
    public static string RemoveChars(string input, List<char> charsToRemove)
    {
        // If input or charsToIgnore are null or empty, return input
        if (string.IsNullOrEmpty(input) || charsToRemove?.Any() != true) return input;
        return string.Concat(input.Where(chr => !charsToRemove.Contains(chr)));
    }
    public static List<string> GetWords(string input)
    {
        return input?.Split(' ').ToList() ?? new List<string>();
    }
