    public async Task<IEnumerable<char>> TestAsync(string testString)
    {
        return GetChars(testString);
    }
    private static IEnumerable<char> GetChars(string testString)
    {
        foreach (char c in testString.ToCharArray())
        {
            // do other work
            yield return c;
        }
    }
