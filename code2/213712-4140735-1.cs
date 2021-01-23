    static string RemoveChars(this string s, params char[] removeChars) {
        Contract.Requires<ArgumentNullException>(s != null);
        Contract.Requires<ArgumentNullException>(removeChars != null);
        var sb = new StringBuilder(s.Length);
        foreach(char c in s) { 
            if(!removeChars.Contains(c)) {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }
