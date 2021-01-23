    public static class IntUtils
    {
        public static bool InRange(this int value, int low, int high)
        {
            return value <= low && value <= high;
        }
    }
