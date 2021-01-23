    static Regex rx = new Regex(@"\G(mis|und|un|der|er|stand|.*)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    // how to test a syllable, just for the purpose of this example
    static string GetSyllable(string word, int index)
    {
        return rx.Match(word, index).Value;
    }
    static List<string> BreakIntoSyllables(string word)
    {
        var list = new List<string>();
        int index = 0;
        while (index < word.Length)
        {
            var match = GetSyllable(word, index);
            list.Add(match);
            index += match.Length;
        }
        return list;
    }
