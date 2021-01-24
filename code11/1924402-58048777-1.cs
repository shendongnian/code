     public static partial class GenericExtensions
    {
    #region SelectAsSource
        public static List<TSource> SelectAsSource<TSource, TResult>(this IQueryable<TSource> source, System.Linq.Expressions.Expression<Func<TSource, TResult>> selector)
        {
            return source
                .Select(selector)
                .ToList()//FetchData From Database
                .Select(x => x.ParseTo<TResult, TSource>())
                .ToList();
        }
        public static List<TSource> SelectAsSource<TSource, TResult>(this IEnumerable<TSource> source, System.Linq.Expressions.Expression<Func<TSource, TResult>> selector)
        {
            return source.ToList().SelectAsSource(selector);
        }
        public static List<TSource> SelectAsSource<TSource, TResult>(this List<TSource> source, System.Linq.Expressions.Expression<Func<TSource, TResult>> selector)
        {
            return source
                .AsQueryable()
                .Select(selector)
                .ToList()//FetchData From Database
                .Select(x => x.ParseTo<TResult, TSource>())
                .ToList();
        }
        #endregion
    }
