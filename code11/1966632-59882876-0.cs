    var m = Regex.Matches(input, @".*{\d+}.*");
    if (m.Any())
    {
        // before any arg
        var sb = new StringBuilder(input.Substring(0, m[0].Index));
        int i = 0;
        for (; i < m.Count; i++)
        {
            // arg itself
            sb.Append(arg[i]);
            // after arg until the next arg or end of input
            int start = m[i].Index + m[i].Value.Length;
            if (i == m.Count - 1)
                sb.Append(input.Substring(start));
            else
            {
                int length = m[i + 1].Index - start;
                sb.Append(input.Substring(start, length));
            }
        }
    }
