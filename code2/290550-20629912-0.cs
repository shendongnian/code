    public static string TakeCharacters(string input, int index, int count)
    {
        if (input == null) return null;
        if (index >= input.Length)
            throw new ArgumentOutOfRangeException(
                "index",
                string.Format("index {0} is out of range (max {1})", index, input.Length - 1));
        if (count <= 0)
            throw new ArgumentException("length should be greater than zero", "count");
    
        var builder = new StringBuilder();
        while (index < input.Length && count > 0)
        {
            var c = StringInfo.GetNextTextElement(input, index);
            builder.Append(c);
            index += c.Length;
            count--;
        }
        return builder.ToString();
    }
