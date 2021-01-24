    public static string RemoveWord(string input, string wordToRemove)
    {
        if (string.IsNullOrEmpty(input)) return input;
        if (string.IsNullOrEmpty(wordToRemove)) return input;
        var currentWord = "";
        var result = "";
        foreach (char chr in input)
        {
            if (chr == ' ')
            {
                if (currentWord != wordToRemove)
                {
                    result += currentWord + " ";
                }
                currentWord = "";
            }
            else
            {
                currentWord += chr;
            }
        }
        if (currentWord != wordToRemove)
        {
            result += currentWord;
        }
        return result;
    }
