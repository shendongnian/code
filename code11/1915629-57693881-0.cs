        // Example usage: ToSetter<MyEntity, string>(c => c.FirstName)
        public static Action<TEntity, TResult> ToSetter<TEntity, TResult>(Expression<Func<TEntity, TResult>> expr)
        {
            // This will be `c.FirstName`
            var memberExpression = (MemberExpression)expr.Body;
            // This will be `c`
            var instanceParameter = (ParameterExpression)memberExpression.Expression;
            // New parameter for passing value named `value`
            var valueParameter = Expression.Parameter(typeof(TResult), "value");
            // Construct `(c, value) => c.FirstName = value`
            return Expression.Lambda<Action<TEntity, TResult>>(
                Expression.Assign(memberExpression, valueParameter), // c.FirstName = value
                instanceParameter, // c
                valueParameter // value
            ).Compile();        
        }
