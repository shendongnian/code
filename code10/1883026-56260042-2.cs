    public static class ObjectExtensions
    {
        public static TOutput Transform<TInput, TOutput>(this TInput input, Func<TInput, TOutput> transform)
        {
            return transform(input);
        }
    }
