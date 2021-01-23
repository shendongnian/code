    StringBuilder builder = new StringBuilder(input.Length * 2);
    foreach (char c in input)
    {
        builder.Append(c);
        builder.Append(',');
    }
    string result = builder.ToString();
