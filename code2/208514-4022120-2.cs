    Regex re = new Regex(regex);
    foreach (Match m in re.Matches(input))
    {
        string field = m.Result("${field}").Replace("\"\"", "\"").Trim();
        // string rowbreak = m.Result("${rowbreak}");
        if (field != string.Empty)
        {
            // Print(field);
        }
    }
