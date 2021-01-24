    var m = Regex.Matches(input, @".*{\d+}.*");
    if (m.Any())
    {
        // before any arg
        var sb = new StringBuilder(input.Substring(0, m[0].Index));
        for (int i = 0; i < m.Count; i++)
        {
            // arg itself
            sb.Append(arg[i]);
            // from right after arg 
            int start = m[i].Index + m[i].Value.Length;
            if (i < m.Count - 1)
            {
                // until next arg
                int length = m[i + 1].Index - start;
                sb.Append(input.Substring(start, length));
            }
            else
                // until end of input
                sb.Append(input.Substring(start));
        }
    }
