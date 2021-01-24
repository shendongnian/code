    public static IEnumerable<string> GetEveryNthWord(string input, int n)
    {
        return input.Split().Where((value, index) => (index + 1) % n == 0);
    }
    public static IEnumerable<string> GetEveryNthWord(IEnumerable<string> input, int n)
    {
        return input.SelectMany(sentence => GetEveryNthWord(sentence, n));
    }
