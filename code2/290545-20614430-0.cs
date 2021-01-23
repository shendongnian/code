    public string GetFirstTenCharacters(string s)
    {
        // This says "If string s is less than 10 characters, return s.
        // Otherwise, return the first 10 characters of s."
        return (s.Length < 10) ? s : s.Substring(0, 10);
    }
