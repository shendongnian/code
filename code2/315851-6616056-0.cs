    static string ProcessString(string input)
    {
        StringBuilder buffer = new StringBuilder();
        for (int i=0; i<input.Length; i++)
        {
            if ((i>0) & (i%2==0))
                buffer.Append(" ");
            buffer.Append(input[i]);
        }
        return buffer.ToString();
    }
