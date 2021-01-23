    public static string RemoveControlCharacters(string inString)
    {
        if (inString == null) return null;
        StringBuilder newString = new StringBuilder();
        char ch;
        for (int i = 0; i < inString.Length; i++)
        {
            ch = inString[i];
            if (!char.IsControl(ch))
            {
                newString.Append(ch);
            }
        }
        return newString.ToString();
    }
