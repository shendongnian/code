    public static class Utils
    {
        public static bool InRange<T>(this T value, T low, T high) where T : IComparable
        {
            return low.CompareTo(value) <= 0 && high.CompareTo(value) >= 0;
        }
    }
