    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> GroupSelect<T>(this IEnumerable<T> list, int groupSize)
        {
            return list
                .Select((t, i) => new { t, i })
                .GroupBy(x => (int)(x.i / groupSize), x => x.t);
        }
    }
