    public static class Converter&lt;TSource, TResult&gt;
    {
        static Converter()
        {
            var sourceParameter = Expression.Parameter(typeof(TSource));
            var conversionExpression = Expression.Lambda&lt;Func&lt;TSource, TResult&gt;&gt;(
                Expression.Convert(sourceParameter, typeof(TResult)),
                sourceParameter);
            Instance = conversionExpression.Compile();
        }
        public static Func&lt;TSource, TResult&gt; Instance
        {
            get;
            private set;
        }
    }
    public static class EnumerableEx
    {
        public static IEnumerable&lt;TResult> Cast&lt;TSource, TResult&gt;(this IEnumerable&lt;TSource&gt; source)
        {
            return source.Select(Converter&lt;TSource, TResult&gt;.Instance);
        }
    }
