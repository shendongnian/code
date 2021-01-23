     public static IQueryable<TEntity> Where<TEntity>(this IQueryable<TEntity> source, string propertyName, string value) 
        {
            Expression<Func<TEntity, bool>> whereExpression = x => x.GetType().InvokeMember(propertyName, BindingFlags.GetProperty, null, x, null).ObjectToString().IndexOf(value, StringComparison.InvariantCultureIgnoreCase) >= 0;
            return source.Where(whereExpression);
            
            
        }
