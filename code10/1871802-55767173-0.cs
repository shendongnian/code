    public static class QueryableExt
    {
        public static Expression<Func<T, bool>> BuildLambda<T>(this IQueryable<T> input, string propertyName, string startsWith)
        {
            var elemenType = input.ElementType;
            var property = elemenType.GetProperty(propertyName);
            if (property == null)
                throw new ArgumentException($"There is no property {propertyName} in {elemenType.Name}");
            if (property.PropertyType != typeof(string))
                throw new ArgumentException($"Expected string property but actual type is {property.PropertyType.Name}");
            var startsWithMethod = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
            var p = Expression.Parameter(elemenType, "p"); // p => ...
            var memberExpression = Expression.Property(p, property); // ... p.Propery
            var startsWithValue = Expression.Constant(startsWith); // "some prefix"
            var startsWithExpression = Expression.Call(memberExpression, startsWithMethod, startsWithValue); // ... p.Property.StartsWith("some prefix")
            var result = Expression.Lambda<Func<T, bool>>(startsWithExpression, p); // p => p.Property.StartsWith("some prefix")
            return result;
        }
    }
