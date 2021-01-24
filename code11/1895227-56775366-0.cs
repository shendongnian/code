    private static Tuple<bool, string> ValidateWord(string[] words)
    {
        bool foundResult = false;
        List<string> all3CharWords = new List<string>();
        string wordWith3SameChar = string.Empty;
    
        foreach (var word in words)
        {
            var resultTuple = ValidateWord(word);
            if (resultTuple.Item1)
            {
                foundResult = true;
                all3CharWords.Add(resultTuple.Item2);
            }
        }
    
        if (foundResult)
        {
            wordWith3SameChar = String.Join(";", all3CharWords.ToArray());
        }
    
        return new Tuple<bool, string>(foundResult, wordWith3SameChar);
    }
    
    
    private static Tuple<bool, string> ValidateWord(string words)
    {
        bool foundResult = false;
        string wordWith3SameChar = string.Empty;
        List<string> traversedChars = new List<string>();
        for(int i = 0; i < words.Length; i++)
        {
            if (!traversedChars.Contains(words[i].ToString()))
            {
                string tripleChar = $"{words[i]}{words[i]}{words[i]}";
                if (words.Contains(tripleChar))
                {
                    foundResult = true;
                    wordWith3SameChar = words;
                    break;
                }
            }
        }
    
        return new Tuple<bool, string>(foundResult, wordWith3SameChar);
    }
