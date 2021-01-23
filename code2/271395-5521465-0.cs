    public static bool UsesSameLetters(string input, string check)
    {
        var OriginalCounts = input.GroupBy(c => c)
            .ToDictionary(g => g.Key, g => g.Count());
        bool Success = check.GroupBy(c => c)
            .All(originalCounts.ContainsKey(g.Key) 
                && originalCounts[g.Key] >= g.Count);
        return Success;
    }
