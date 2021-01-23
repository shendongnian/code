    static string EnforceCharLimitation(string textChars, string allowChars)
    {
        string tempResult = "";
        foreach (char c in textChars)
        {
            if (allowChars.Contains(c))
            {
                tempResult = tempResult + c;
            }
        }
        return tempResult;
    }
