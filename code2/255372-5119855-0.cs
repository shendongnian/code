    public static class Extensions
    {
        public static Boolean In<T>(this T obj, params T[] items)
        {
            return items.Contains(obj);
        }
    }
