    static IEnumerable<string> Splitter(string sentences)
    {
        foreach (string s in 
            Regex.Split(sentences, "(?<!((mr)|(mrs)))\\.", RegexOptions.IgnoreCase))
        {
            if (!String.IsNullOrWhiteSpace(s)) yield return s.Trim();
        }
    }
