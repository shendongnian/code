    bool IsAllDigits(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return false;
        }
        return s.All(char.IsDigit);
    }
