    public static int FindCountOfCharBeforeAnotherChar(string text, char find, char findBefore)
    {
        var indexOfFindBefore = text.IndexOf(findBefore);
        if (indexOfFindBefore < 1) return 0;
        var textBeforeMatch = text.Substring(0, indexOfFindBefore);
        return textBeforeMatch.Count(c => c == find);
    }
    [TestCase("aXa", 1)]
    [TestCase("aaXa", 2)]
    [TestCase("aaa", 0)]
    [TestCase("Xaa", 0)]
    public void FindsExpectedCharacterCount(string text, int expected)
    {
        Assert.AreEqual(expected, FindCountOfCharBeforeAnotherChar(text, find:'a', findBefore:'X'));
    }
