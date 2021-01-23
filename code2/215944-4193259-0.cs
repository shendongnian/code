    public static bool TryParse(string s, out MinMax result)
    {
        string parts = s.Split(' ');
        if (parts.Length == 2)
        {
            float min, max;
            if (float.TryParse(parts[0].Trim(), out min)
                    && float.TryParse(parts[1].Trim(), out max))
            {
                result = new MinMax(min, max);
                return true;
            }
        }
        result = default(MinMax);    // or just use "result = new MinMax(0, 0);"
        return false;
    }
