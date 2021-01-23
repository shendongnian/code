    public IEnumerable<T> Filter<T>(IEnumerable<T> collection, Dictionary<string, object> filters) {
        var type = typeof (T);
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var queryable = collection.AsQueryable();
    
        var expressions = new List<Expression>();
    
        foreach (var filter in filters) {
            var propertyName = filter.Key;
            var property = properties.FirstOrDefault(x => x.Name == propertyName);
            if (property == null)
                continue;
    
            var instance = Expression.Parameter(type, "instance");
            var left = Expression.Property(instance, property);
            var right = Expression.Constant(filter.Value, property.PropertyType);
            var expr = Expression.Equal(left, right);
    
            var whereCallExpression = Expression.Call(
                typeof (Queryable),
                "Where",
                new[] {queryable.ElementType},
                queryable.Expression,
                Expression.Lambda<Func<T, bool>>(expr, new[] {instance}));
    
            expressions.Add(whereCallExpression);
        }
    
        foreach(var expr in expressions) {
            queryable = queryable.Provider.CreateQuery<T>(expr);
        }
    
        return queryable.ToList();
    }
