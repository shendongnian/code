    private Dictionary<char, int> WordToChars(string word)
    {
        var result = new Dictionary<char, int>();
        foreach (var c in word)
        {
            if (result.ContainsKey(c))
            {
                result[c] += result[c] + 1;
            }
            else
            {
                result[c] = 1;
            }
        }
        return result;
    }
    private bool DoesMatchPattern(string patternString, string testString)
    {
        var pattern = WordToChars(patternString);
        var test = WordToChars(testString);
        return test.All(x => pattern.TryGetValue(x.Key, out int qty) && qty >= x.Value);
    }
