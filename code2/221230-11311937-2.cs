    public static Double Val(string value)
    {
        String result = String.Empty;
        foreach (char c in value)
        {
            if (Char.IsNumber(c) || (c.Equals('.') && result.Count(x => x.Equals('.')) == 0))
                result += c;
            else if (!c.Equals(' '))
                return String.IsNullOrEmpty(result) ? 0 : Convert.ToDouble(result);
        }
        return String.IsNullOrEmpty(result) ? 0 : Convert.ToDouble(result);
    }
