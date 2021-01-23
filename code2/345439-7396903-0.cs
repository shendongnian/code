    static string RemoveCharsFromString(string textChars, string removeChars)
    {
        string tempResult = "";
        foreach (char c in textChars)
        {
            if (!removeChars.Contains(c))
            {
                tempResult = tempResult + c;
            }
        }
        return tempResult;
    }
