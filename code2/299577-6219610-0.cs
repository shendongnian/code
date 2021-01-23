    static string RemoveWhitespace(string input)
    {
        StringBuilder output = new StringBuilder(input.Length);
    
        for (int index = 0; index < input.Length; index++)
        {
            if (!Char.IsWhiteSpace(input, index))
            {
                output.Append(input[index]);
            }
        }
    
        return output.ToString();
    }
