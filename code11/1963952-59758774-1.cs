    public static class FilterExpression
    {
        public static IQueryable<T> ApplySearch<T>(this IQueryable<T> source, string search)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (string.IsNullOrWhiteSpace(search)) return source;
    
            var parameter = Expression.Parameter(typeof(T), "e");
            // The following simulates closure to let EF Core create parameter rather than constant value (in case you use `Expresssion.Constant(search)`)
            var value = Expression.Property(Expression.Constant(new { search }), nameof(search));
            var body = SearchStrings(parameter, value);
            if (body == null) return source;
    
            var predicate = Expression.Lambda<Func<T, bool>>(body, parameter);
            return source.Where(predicate);
        }
    
        static Expression SearchStrings(Expression target, Expression search)
        {
            Expression result = null;
    
            var properties = target.Type
              .GetProperties()
              .Where(x => x.CanRead);
    
            foreach (var prop in properties)
            {
                Expression condition = null;
                var propValue = Expression.MakeMemberAccess(target, prop);
                if (prop.PropertyType == typeof(string))
                {
                    var comparand = Expression.Call(propValue, nameof(string.ToLower), Type.EmptyTypes);
                    condition = Expression.Call(comparand, nameof(string.Contains), Type.EmptyTypes, search);
                }
                else if (!prop.PropertyType.Namespace.StartsWith("System."))
                {
                    condition = SearchStrings(propValue, search);
                }
                if (condition != null)
                    result = result == null ? condition : Expression.OrElse(result, condition);
            }
    
            return result;
        }
    }
