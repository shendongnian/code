    bool IsAllDigits(string s)
    {
        foreach (char c in s)
        {
            if (!Char.IsDigits(c))
                return false;
        }
        return true;
    }
