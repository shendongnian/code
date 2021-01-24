    public static (double result, int consumed) ParseLongestNumber(string s)
    {
        const string NUMBER_CHARS = "+-.,e0123456789";
        int n = 0;
        while (n < s.Length)
            if (NUMBER_CHARS.IndexOf(s[n]) < 0)
                break;
            else
                ++n;
        for (; n > 0; --n)
        {
            string t = s.Substring(0, n);
            if (double.TryParse(t, out var r))
                return (r, n);
        }
        return (double.NaN, 0);
    }
