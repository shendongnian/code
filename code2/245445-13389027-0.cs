    public static class LinqExtensions
    {
        public static Expression<Func<T, bool>> WildCardWhere<T>(this Expression<Func<T, bool>> source, Expression<Func<T, string>> selector, string terms, char separator)
        {
            if (terms == null || selector == null)
                return source;
            foreach (string term in terms.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries))
            {
                string current = term;
                source = source.And(
                    Expression.Lambda<Func<T, bool>>(
                        Expression.Call(selector.Body, "Contains", null, Expression.Constant(current)),
                        selector.Parameters[0]
                    )
                );
            }
            return source;
        }
    }
