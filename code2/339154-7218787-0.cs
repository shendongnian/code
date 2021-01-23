    public static class Maybe
    {
        public static TResult With<T, TResult>(this T self, Func<T, TResult> func) where T : class
        {
            if (self != null)
                return func(self);
            return default(TResult);
        }
        public static TResult Return<T, TResult>(this T self, Func<T, TResult> func, TResult result) where T : class
        {
            if (self != null)
                return func(self);
            return result;
        }
    }
