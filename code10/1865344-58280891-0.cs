    public static class MyExtensions
    {
        public static MethodInfo GetMethod<TSource, TResult>(this Expression<Func<TSource, TResult>> lambda)
            => (lambda?.Body as MethodCallExpression)?.Method ?? throw new ArgumentException($"Not a {nameof(MethodCallExpression)}.");
        private static readonly MethodInfo _miWhere = GetMethod((IQueryable<int> q) => q.Where(x => false)).GetGenericMethodDefinition();
        public static IQueryable<TSource> WhereGreaterThan<TSource, TCompare>(this IQueryable<TSource> source, Expression<Func<TSource, TCompare>> selector, Expression<Func<TCompare>> comparand)
        {
            var predicate = Expression.Lambda<Func<TSource, bool>>(Expression.GreaterThan(selector.Body, comparand.Body), selector.Parameters[0]);
            var where = Expression.Call(_miWhere.MakeGenericMethod(typeof(TSource)), source.Expression, predicate);
            return source.Provider.CreateQuery<TSource>(where);
        }
    }
