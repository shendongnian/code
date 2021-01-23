    static class ExtensionMethods
    {
        public static string GetPropertyColumn<T,U>(this T obj, Expression<Func<T, U>> selector)
        {
            ... // whatever
        }
    }
