    bool IsNumber(string s)
    {
        foreach (char c in s)
        {
            if (!Char.IsDigit(c))
                return false;
        }
        return (s.Length > 0);
    }
