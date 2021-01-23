    public static class IComparableExtension
    {
        public static bool InRange(this IComparable value, object from, object to)
        {
            return value.CompareTo(from) == 1 && value.CompareTo(to) == -1;
        }
    }
