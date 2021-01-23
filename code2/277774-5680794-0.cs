    StringBuilder sb = new StringBuilder();
    foreach (char c in input)
    {
        if (Char.IsLetterOrDigit(c) ||
            c == '.' || c == '_' || c == ' ' || c == '%')
            sb.Append(c);
        }
    }
    return sb.ToString();
