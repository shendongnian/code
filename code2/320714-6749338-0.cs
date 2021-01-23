    public static class NastyExtensions
    {
        public static ushort GetIdentifier<T>(this T actualValueIsIgnored)
        {
            Type type = typeof(T);
            ... code as before
        }
    }
