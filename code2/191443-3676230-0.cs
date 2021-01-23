    public static class EnumerableEx
    {
        public static IEnumerable<T> OfThese<T>(params T[] objects)
        {
            return objects;
        }
    }
