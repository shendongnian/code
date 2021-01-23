    string[] SplitByCaps(string input)
    {
        StringBuilder output = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];
            if (i > 0 && Char.IsUpper(c))
                output.Append(' ');
            output.Append(c);
        }
        return output.ToString().Split(' ');         
    }
