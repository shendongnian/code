    bool TryParse(string s, out int x)
    {
        if (!consistsOnlyOfDigits(s))
        {
            x = 0;
            return false;
        }
        // More checks...
        // Parse the string...
        x = 42;
        return true;
    }
