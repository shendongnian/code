    string Commaize (IEnumerable<string> list)
    {
        string previous = null;
        StringBuilder sb = new StringBuilder();
        foreach(string s in list)
        {
            if (previous != null)
                sb.AppendFormat("{0}, ", previous);
            previous = s;
        }
        if (previous != null)
        {
            if (sb.Length > 0)
                sb.AppendFormat("and {0}", previous);
            else
                sb.Append(previous);
        }
        return sb.ToString();
    }
