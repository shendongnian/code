    public static class Extenstions
    {
        public static IEnumerable<TRestul> ToFormattedList<TElement, TRestul>(
            this IEnumerable<TElement> source,
            int count,
            Func<List<TElement>, TRestul> formatter)
        {
            return source.Split(count).Select(arg => formatter(arg.ToList()));
        }
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, int size)
        {
            var i = 0;
            return
                from element in source
                group element by i++ / size into splitGroups
                select splitGroups.AsEnumerable();
        }
    }
