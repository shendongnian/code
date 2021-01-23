    string FirstUpper(string s)
    {
        // Check for empty string.
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }
        s = s.ToLower();
        // Return char and concat substring.
        return char.ToUpper(s[0]) + s.Substring(1);
    }
