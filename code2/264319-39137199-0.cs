     public static class NumericExtentions
        {
            public static bool InRange(this int value, int from, int to)
            {
                if (value >= from && value <= to)
                    return true;
                return false;
            }
    
            public static bool InRange(this double value, double from, double to)
            {
                if (value >= from && value <= to)
                    return true;
                return false;
            }
        }
