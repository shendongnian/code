    public static class DefaultConverter<TInput, TOutput>
    {
        private static Converter<TInput, TOutput> cached;
        static DefaultConverter()
        {
            ParameterExpression p = Expression.Parameter(typeof(TSource));
            cached = Expression.Lambda<Converter<TSource, TCastTo>(Expression.Convert(p, typeof(TCastTo), p).Compile();
        }
        public static Converter<TInput, TOutput> Instance { return cached; }
    }
    public static class DefaultConverter<TOutput>
    {
         public static TOutput ConvertBen<TInput>(TInput from) { return DefaultConverter<TInput, TOutput>.Instance.Invoke(from); }
         public static TOutput ConvertEric(dynamic from) { return from; }
    }
