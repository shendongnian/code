    private static string RemoveWhiteSpace(string text) {
        StringBuilder ret = new StringBuilder(text.Length);
        foreach(char c in text) {
            if ( false == char.IsWhiteSpace(c) ) { ret.Append(c); }
        }
    
        return ret.ToString();
    }
