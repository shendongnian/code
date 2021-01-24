    using System.Linq.Expressions;
    namespace System.Linq
    {
        public static class MyQueryableOrderExtensions
        {
            public static IOrderedQueryable<TSource> OrderByDirection<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, bool ascending)
            {
                if (ascending)
                    return source.OrderBy(keySelector);
                else
                    return source.OrderByDescending(keySelector);
            }
            public static IOrderedQueryable<TSource> ThenByDirection<TSource, TKey>(this    IOrderedQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, bool ascending)
            {
                if (ascending)
                    return source.ThenBy(keySelector);
                else
                    return source.ThenByDescending(keySelector);
            }
        }
    }
