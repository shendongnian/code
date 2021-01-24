    public static class MyExtensions
    {
        /// <summary>
        /// Helper method to get a <see cref="MethodInfo"/>.
        /// </summary>
        public static MethodInfo GetMethod<TSource, TResult>(this Expression<Func<TSource, TResult>> lambda)
            => ((MethodCallExpression)(lambda.Body)).Method;
        // some well known methods
        private static readonly MethodInfo _miAny1 = GetMethod((IQueryable<int> q) => q.Any()).GetGenericMethodDefinition();
        private static readonly MethodInfo _miAny2 = GetMethod((IQueryable<int> q) => q.Any(x => false)).GetGenericMethodDefinition();
        private static readonly MethodInfo _miWhere = GetMethod((IQueryable<int> q) => q.Where(x => false)).GetGenericMethodDefinition();
        public static IQueryable<TSource> WhereNotAnyOtherThatEqualsOnCorrespondingFields<TSource, TOther>(
            this IQueryable<TSource> source,
            Expression<Func<IQueryable<TOther>>> other,
            params string[] fieldNames)
        {
            var pThis = Expression.Parameter(typeof(TSource), "pa");
            var pOther = Expression.Parameter(typeof(TOther), "pm");
            Expression anyPredicateBody = null;
            foreach (var field in fieldNames)
            {
                var equal = Expression.Equal(Expression.PropertyOrField(pThis, field), Expression.PropertyOrField(pOther, field)); 
                anyPredicateBody = anyPredicateBody == null ? equal : Expression.AndAlso(anyPredicateBody, equal);
            }
            Expression any;
            if (anyPredicateBody == null)
                any = Expression.Call(_miAny1.MakeGenericMethod(typeof(TOther)), other.Body);
            else
            {
                var anyPredicate = Expression.Quote(Expression.Lambda<Func<TOther, bool>>(anyPredicateBody, pOther));
                any = Expression.Call(_miAny2.MakeGenericMethod(typeof(TOther)), other.Body, anyPredicate);
            }
            var whereNotAnyPredicate = Expression.Quote(Expression.Lambda<Func<TSource, bool>>(Expression.Not(any), pThis));
            var whereNotAny = Expression.Call(_miWhere.MakeGenericMethod(typeof(TSource)), source.Expression, whereNotAnyPredicate);
            return source.Provider.CreateQuery<TSource>(whereNotAny);
        }
    }
