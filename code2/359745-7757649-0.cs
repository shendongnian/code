    public static class LinqQueries
    {
        private static MethodInfo miTL = typeof(String).GetMethod("ToLower", Type.EmptyTypes);
        private static MethodInfo miS = typeof(String).GetMethod("StartsWith", new Type[] { typeof(String) });
        private static MethodInfo miC = typeof(String).GetMethod("Contains", new Type[] { typeof(String) });
        private static MethodInfo miE = typeof(String).GetMethod("EndsWith", new Type[] { typeof(String) });
        public static IQueryable<T> FilterByString<T>(this IQueryable<T> query,
                                                      Expression<Func<T, string>> propertySelector,
                                                      StringOperator operand,
                                                      string value)
        {
            ParameterExpression parameterExpression = null;
            var memberExpression = GetMemberExpression(propertySelector.Body, out parameterExpression);
            var dynamicExpression = Expression.Call(memberExpression, miTL);
            Expression constExp = Expression.Constant(value.ToLower());
            switch (operand)
            {
                case StringOperator.StartsWith:
                    dynamicExpression = Expression.Call(dynamicExpression, miS, constExp);
                    break;
                case StringOperator.Contains:
                    dynamicExpression = Expression.Call(dynamicExpression, miC, constExp);
                    break;
                case StringOperator.EndsWith:
                    dynamicExpression = Expression.Call(dynamicExpression, miE, constExp);
                    break;
            }
            var pred = Expression.Lambda<Func<T, bool>>(dynamicExpression, new[] { parameterExpression });
            return query.Where(pred);
        }
        
        private static Expression GetMemberExpression(Expression expression, out ParameterExpression parameterExpression)
        {
            parameterExpression = null;
            if (expression is MemberExpression)
            {
                var memberExpression = expression as MemberExpression;
                while (!(memberExpression.Expression is ParameterExpression))
                    memberExpression = memberExpression.Expression as MemberExpression;
                parameterExpression = memberExpression.Expression as ParameterExpression;
                return expression as MemberExpression;
            }
            if (expression is MethodCallExpression)
            {
                var methodCallExpression = expression as MethodCallExpression;
                parameterExpression = methodCallExpression.Object as ParameterExpression;
                return methodCallExpression;
            }
            return null;
        }
    }
