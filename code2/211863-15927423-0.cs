    public string TrimStart(string inputText, string value, bool ignoreCase = false)
    {
        if (!string.IsNullOrEmpty(value))
        { 
            while (!string.IsNullOrEmpty(inputText) && inputText.StartsWith(value, ignoreCase))
            {
                inputText = inputText.Substring(value.Length - 1);
            }
        }
    
        return inputText;
    }
    
    public string TrimEnd(string inputText, string value, bool ignoreCase = false)
    {
        if (!string.IsNullOrEmpty(value))
        {
            while (!string.IsNullOrEmpty(inputText) && inputText.EndsWith(value, ignoreCase))
            {
                inputText = inputText.Substring(0, (inputText.Length - value.Length));
            }
        }
    
        return inputText;
    }
    
    public string Trim(string inputText, string value, bool ignoreCase = false)
    {
        return TrimStart(TrimEnd(inputText, value, ignoreCase), value, ignoreCase);
    }
