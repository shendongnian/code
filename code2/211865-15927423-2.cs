    public string TrimStart(string inputText, string value, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase)
    {
        if (!string.IsNullOrEmpty(value))
        { 
            while (!string.IsNullOrEmpty(inputText) && inputText.StartsWith(value, comparisonType))
            {
                inputText = inputText.Substring(value.Length - 1);
            }
        }
    
        return inputText;
    }
    
    public string TrimEnd(string inputText, string value, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase)
    {
        if (!string.IsNullOrEmpty(value))
        {
            while (!string.IsNullOrEmpty(inputText) && inputText.EndsWith(value, comparisonType))
            {
                inputText = inputText.Substring(0, (inputText.Length - value.Length));
            }
        }
    
        return inputText;
    }
    
    public string Trim(string inputText, string value, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase)
    {
        return TrimStart(TrimEnd(inputText, value, comparisonType), value, comparisonType);
    }
