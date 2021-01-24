    static int StringToInt(string v)
    {
        const int BASE = 10;
        int result = 0;
        int currentBase = 1;
        for (int digitIndex = v.Length - 1; digitIndex >= 0; --digitIndex)
        {
            int digitValue = (int)Char.GetNumericValue(v[digitIndex]);
            int accum = 0;
            for (int i = 0; i < BASE; ++i)
            {
                if (i == digitValue)
                {
                    result += accum;
                }
                accum += currentBase;
            }
            currentBase = accum;
        }
        return result;
    }
