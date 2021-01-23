    static string ConvertWord(string word, HashSet<string> discovered)
    {
        StringBuilder sb = new StringBuilder(word.Length);
        foreach (char c in word)
        {
            if (discovered.Contains(c.ToString()))
            {
                sb.Append(c);
            }
            else
            {
                sb.Append('_');
            }
        }
        return sb.ToString();
    }
    HashSet<string> discovered = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);
    // The "secret" word
    string word = "Hello world";
    // How to add letters to the ones discovered
    discovered.Add("l");
    // The word ready to be shown
    string convertWord = ConvertWord(word, discovered);
