        public static IQueryable<T> Where<T, TProperty>(this IQueryable<T> source,
            Expression<Func<T, TProperty>> propertySelector,
            Expression<Func<TProperty, bool>> predicate)
        {
            MemberExpression member = propertySelector.Body as MemberExpression;
            if (member == null)
                throw new ArgumentException("Must be a property selector", "propertySelector");
            string propertyName = member.Member.Name;
            // The input type
            ParameterExpression propertyParameter = Expression.Parameter(typeof(T));
            // The property on that type
            MemberExpression itemProperty = Expression.Property(propertyParameter, propertyName);
            // Invoke the specified predicate with the property from the input type
            InvocationExpression invokeExpression = Expression.Invoke(predicate, itemProperty);
            // The lambda expression for use with Linq
            Expression<Func<T, bool>> finalExpression = Expression.Lambda<Func<T, bool>>(invokeExpression, propertyParameter);
            return source.Where(finalExpression);
        }
