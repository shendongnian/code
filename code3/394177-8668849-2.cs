    public IEnumerable<string> SplitString(string input)
    {
        var isInDoubleQuote = false;
        var isInSingleQuote = false;
        var sb = new StringBuilder();
        foreach (var c in input)
        {
            if (!isInDoubleQuote && c == '"')
            {
                isInDoubleQuote = true;
                sb.Append(c);
            }
            else if (isInDoubleQuote)
            {
                sb.Append(c);
                if (c != '"')
                    continue;
                if (sb.Length > 2)
                    yield return sb.ToString();
                sb = sb.Clear();
                isInDoubleQuote = false;
            }
            else if (!isInSingleQuote && c == '\'')
            {
                isInSingleQuote = true;
                sb.Append(c);
            }
            else if (isInSingleQuote)
            {
                sb.Append(c);
                if (c != '\'')
                    continue;
                if (sb.Length > 2)
                    yield return sb.ToString();
                sb = sb.Clear();
                isInSingleQuote = false;
            }
            else if (c == ' ')
            {
                if (sb.Length == 0)
                    continue;
                yield return sb.ToString();
                sb.Clear();
            }
            else
                sb.Append(c);
        }
        if (sb.Length > 0)
            yield return sb.ToString();
    }
