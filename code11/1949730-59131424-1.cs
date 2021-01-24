    static private string Escape(string s)
    { 
        const string QUOTE = "\""; 
        const string ESCAPED_QUOTE = "\"\""; 
        char[] CHARACTERS_THAT_MUST_BE_QUOTED = { ',', '"', '\n' };
        if (s.Contains(QUOTE))
            s = s.Replace(QUOTE, ESCAPED_QUOTE);
        if (s.IndexOfAny(CHARACTERS_THAT_MUST_BE_QUOTED) > -1)
            s = QUOTE + s + QUOTE;
        return s;
    }
