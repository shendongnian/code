    public static (double result, int consumed) ParseLongestNumber(string s)
    {
        for (int n = s.Length; n > 0; --n)
        {
            string t = s.Substring(0, n);
            if (double.TryParse(t, out var r))
                return (r, n);
        }
        return (double.NaN, 0);
    }
