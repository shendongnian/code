    public static class MyExtension
    {
        public static TSource? NullOrFirst<TSource>(this IEnumerable<TSource> source) where TSource : struct
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            IList<TSource> list = source as IList<TSource>;
            if (list != null)
            {
                if (list.Count > 0)
                {
                    return list[0];
                }
            }
            else
            {
                using (IEnumerator<TSource> enumerator = source.GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        return enumerator.Current;
                    }
                }
            }
            return null;
        }
    }
