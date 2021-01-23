    static string[] GetWords(string input)
    {
        MatchCollection matches = Regex.Matches(input, @"\b[\w']*\b");
        var words = from m in matches.Cast<Match>()
                            where !string.IsNullOrEmpty(m.Value)
                            select TrimPossessive(m.Value);
        return words.ToArray();
    }
    static string TrimPossessive(string word)
    {
        if (word.EndsWith("'s"))
        {
            word = word.Substring(0, word.Length - 2);
        }
        else if (word.EndsWith("'"))
        {
            word = word.Substring(0, word.Length - 1);
        }
        return word;
    }
