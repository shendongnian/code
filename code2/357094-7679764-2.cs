    StringBuilder sb = new StringBuilder();
    foreach (char c in s)
    {
        if ("+-&|!(){}[]^\"~*?:\\".Contains(c))
        {
            sb.Append('\\');
        }
        sb.Append(c);
    }
    s = sb.ToString();
