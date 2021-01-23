    public static class GenericListExtensions
    {
        public static void ToString<T>(this IList<T> list)
        {
            return string.Join(", ", this.ToArray());
        }
    }
