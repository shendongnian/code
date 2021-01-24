    public static class StringExtensions
    {
        public static TDest ConvertStringTo<TDest>(this string src)
        {
            if (src == null)
            {
                return default(TDest);
            }
            try
            {
                return ChangeType<TDest>(src);
            }
            catch
            {
                return default(TDest);
            }
        }
        private static T ChangeType<T>(string value)
        {
            var t = typeof(T);
            if (t.GetTypeInfo().IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                t = Nullable.GetUnderlyingType(t);
            }
            return (T)Convert.ChangeType(value, t);
        }
    }
