    static string RemoveChars(this string s, params char[] removeChars) {
        Contract.Requires(removeChars != null);
        foreach(char c in removeChars) {
            s = s.Remove(c.ToString(), String.Empty);
        }
        return s;
    }
