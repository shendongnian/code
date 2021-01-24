    public static class Extensions
    {
        public static IEnumerable<T> Find<T>(this IEnumerable<Transformable> list, Func<T,bool> predicate) where T :Transformable
        {
            return list.OfType<T>().Where(predicate.Invoke);
        }
    }
