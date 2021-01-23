    StringBuilder sb = new StringBuilder();
    foreach (char c in str)
    {
        if (Char.IsNumber(c))
        {
            sb.append(c);
        }
    }
    return Convert.ToInt32(sb.ToString());
