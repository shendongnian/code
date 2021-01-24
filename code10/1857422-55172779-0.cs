    private static Dictionary<string, int> GetWords(string input)
    {
        var result = new Dictionary<string, int>();
        if (string.IsNullOrWhiteSpace(input)) return result;
        var currentWord = "";
        foreach (var chr in input)
        {
            if (char.IsLetter(chr))
            {
                currentWord += chr;
            }
            else if (currentWord.Length > 0)
            {
                if (result.ContainsKey(currentWord)) result[currentWord]++;
                else result.Add(currentWord, 1);
                currentWord = "";
            }
        }
        if (currentWord.Length > 0)
        {
            if (result.ContainsKey(currentWord)) result[currentWord]++;
            else result.Add(currentWord, 1);
        }
        return result;
    }
