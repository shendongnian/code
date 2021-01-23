    void Main() {
        string a = "background color-red.brown";
        string camelCase = ConvertCaseString(a, Case.CamelCase);
        string pascalCase = ConvertCaseString(a, Case.PascalCase);
    }
    
    /// <summary>
    /// Converts the phrase to specified convention.
    /// </summary>
    /// <param name="phrase"></param>
    /// <param name="cases">The cases.</param>
    /// <returns>string</returns>
    static string ConvertCaseString(string phrase, Case cases)
    {
        string[] splittedPhrase = phrase.Split(' ', '-', '.');
        var sb = new StringBuilder();
    
        if (cases == Case.CamelCase)
        {
            sb.Append(splittedPhrase[0].ToLower());
            splittedPhrase[0] = string.Empty;
        }
        else if (cases == Case.PascalCase)
            sb = new StringBuilder();
    
        foreach (String s in splittedPhrase)
        {
            char[] splittedPhraseChars = s.ToCharArray();
            if (splittedPhraseChars.Length > 0)
            {
                splittedPhraseChars[0] = ((new String(splittedPhraseChars[0], 1)).ToUpper().ToCharArray())[0];
            }
            sb.Append(new String(splittedPhraseChars));
        }
        return sb.ToString();
    }
    
    enum Case
    {
        PascalCase,
        CamelCase
    }
