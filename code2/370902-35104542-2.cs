    public static class HintExtension
    {
        public static DbSet<T> WithHint<T>(this DbSet<T> set, string hint) where T : class
        {
            HintInterceptor.HintValue = hint;
            return set;
        }
    }
