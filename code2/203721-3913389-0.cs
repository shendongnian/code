    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, Func<T, bool> isSeparator)
        {
            var list = new List<T>();
            foreach (var item in source)
            {
                if (isSeparator(item))
                {
                    if (list.Count > 0)
                    {
                        yield return list.AsReadOnly();
                    }
                    list = new List<T>();
                }
                else
                {
                    list.Add(item);
                }
            }
            if (list.Count > 0)
            {
                yield return list.AsReadOnly();
            }
        }
    }
