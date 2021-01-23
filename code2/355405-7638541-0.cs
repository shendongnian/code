    public int GetNumber(string input)
    {
        string result = "";
        
        foreach (Char c in input)
        {
            if (Char.IsDigit(c))
                result += c;
        }
        return Convert.ToInt32(result);
    }
    public string GetCode(string input)
    {
        string result = "";
        
        foreach (Char c in input)
        {
            if (!Char.IsDigit(c))
                result += c;     // or return the char if you want only the first one.
        }
        return result;
    }
