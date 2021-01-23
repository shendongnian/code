    StringBuilder builder = new StringBuilder();
    foreach (char c in str_a)
    {
        if (Char.IsDigit(c))
        {
            builder.Append(c);
        }
    }
    int in_b = Int32.Parse(builder.ToString());
