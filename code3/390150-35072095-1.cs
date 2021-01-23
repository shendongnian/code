    public static class NullExtensionMethods
    {
        public static void ThrowIfHasNull<T>(this IEnumerable collection)
            where T : Exception, new()
        {
            foreach (var item in collection)
            {
                if (item == null)
                {
                    throw new T();
                }
            }
        }
        public static void ThrowIfHasNull(this IEnumerable collection)
        {
            ThrowIfHasNull<NullReferenceException>(collection);
        }
    }
