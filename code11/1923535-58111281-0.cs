    /// <summary>
    /// Set a regular expression to the Text Tab
    /// </summary>
    /// <param name="textTab">Text Tab</param>
    /// <param name="text">Text which will be converted into the regular expression</param>
    private void SetRegex(TextTab textTab, string text)
    {
        if (!string.IsNullOrEmpty(text))
        {
            var regex = GetRegExWithoutCasse(text);
            textTab.ValidationPattern = regex;
            textTab.ValidationMessage = string.Format("Please type: {0}", text);
        }
    }
    
    /// <summary>
    /// Get the RegEx associated to the text without casing-check
    /// </summary>
    /// <param name="text">Text to check</param>
    /// <returns>Regular expression</returns>
    private string GetRegExWithoutCasse(string text)
    {
        var result = string.Empty;
        foreach (var letter in text.Select(i => i.ToString()))
        {
            if (Regex.IsMatch(letter, @"^[a-zA-Z]+$"))
                result += "[" + letter.ToLower() + letter.ToUpper() + "]";
            else
            {
                var textWithoutDiacritics = RemoveDiacritics(letter);
                if (textWithoutDiacritics != letter)
                    result += "[" + textWithoutDiacritics.ToLower() + textWithoutDiacritics.ToUpper() + letter.ToLower() + letter.ToUpper() + "]";
                else
                    result += letter.ToString();
            }
        }
    
        return "^" + result + "$";
    }
    
    /// <summary>
    /// Remove diacritics from text
    /// </summary>
    /// <param name="text">Text</param>
    /// <returns>Clean text</returns>
    private string RemoveDiacritics(string text)
    {
        var tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(text);
        var asciiStr = System.Text.Encoding.UTF8.GetString(tempBytes);
        return asciiStr;
    }
