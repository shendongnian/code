    public static IEnumerable<T> ModelPagination<T>(F filter) 
    {
            // all properties which are in the fiter class also present in the generic type T
            var commonPropertyNames = filter
                    .GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Select(x => x.Name)
                    .Intersect(
                        typeof(T)
                        .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                        .Select(x => x.Name)
                    );
            var argumentExpression = Expression.Parameter(typeof(T), "x");
            var filterConstantExpression = Expression.Constant(filter);
            
            // build the expression
            var expression = (BinaryExpression)null;
            foreach (var propertyName in commonPropertyNames)
            {
                var filterPropertyExpression = Expression.Property(filterConstantExpression, propertyName);
                var equalExpression = Expression.Equal(
                    Expression.Property(argumentExpression, propertyName),
                    filterPropertyExpression
                );
                var nullCheckExpression = Expression.Equal(
                    filterPropertyExpression,
                    Expression.Constant(null)
                );
                var orExpression = Expression.OrElse(equalExpression, nullCheckExpression);
                if (expression == null)
                {
                    expression = orExpression;
                }
                else
                {
                    expression = Expression.AndAlso(expression, orExpression);
                }
            }
            
            var lambda = Expression.Lambda<Func<T, bool>>(expression, argumentExpression);
            return dbContext.Entry<T>().Where(lambda).ToList();
        }
