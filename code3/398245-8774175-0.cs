    public int ParseBinary(string value)
    {
        int res = 0;
        // I'm totally skipping error handling here
        foreach(char c in value)
        {
            res <<= 1;
            res += c == '1' ? 1 : 0;
        }
        return res;
    }
