    public string RemoveDuplicateChars(string input)
    {
        var stringBuilder = new StringBuilder(input);
        foreach (char c in input)
        {
            stringBuilder.Replace(c.ToString(), string.Empty)
                         .Append(c.ToString());
        }
 
        return stringBuilder.ToString();
    }
