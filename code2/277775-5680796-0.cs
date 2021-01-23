    StringBuilder sb = new StringBuilder();
    foreach (char c in input)
    {
        if (char.IsLetterOrDigit(c) || "_ %.".Contains(c.ToString()))
            sb.Append(c);
    }
    return sb.ToString();
