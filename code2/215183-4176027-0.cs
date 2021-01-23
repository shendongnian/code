    public static class IListExtensions
    {
        public static T FindFirst<T>(this IList<T> source, Func<T, bool> condition)
        {
            foreach(T item in source)
                if(condition(item))
                    return item;
            return default(T);
        }
    }
