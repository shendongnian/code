    public static class NullHandling
    {
        /// <summary>
        /// Returns the value specified by the expression or Null or the default value of the expression's type if any of the items in the expression
        /// return null. Use this method for handling long property chains where checking each intermdiate value for a null would be necessary.
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="instance"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static TResult GetValueOrDefault<TObject, TResult>(this TObject instance, Expression<Func<TObject, TResult>> expression) 
            where TObject : class
        {
            var result = GetValue(instance, expression.Body);
            return result == null ? default(TResult) : (TResult) result;
        }
        private static object GetValue(object value, Expression expression)
        {
            object result;
            if (value == null) return null;
            switch (expression.NodeType)
            {
                case ExpressionType.Parameter:
                    return value;
                case ExpressionType.MemberAccess:
                    var memberExpression = (MemberExpression)expression;
                    result = GetValue(value, memberExpression.Expression);
                    return result == null ? null : GetValue(result, memberExpression.Member);
                case ExpressionType.Call:
                    var methodCallExpression = (MethodCallExpression)expression;
                    if (!SupportsMethod(methodCallExpression))
                        throw new NotSupportedException(methodCallExpression.Method + " is not supported");
                    result = GetValue(value, methodCallExpression.Method.IsStatic
                                                 ? methodCallExpression.Arguments[0]
                                                 : methodCallExpression.Object);
                    return result == null
                               ? null
                               : GetValue(result, methodCallExpression.Method);
                case ExpressionType.Convert:
                    var unaryExpression = (UnaryExpression) expression;
                    return Convert(GetValue(value, unaryExpression.Operand), unaryExpression.Type);
                default:
                    throw new NotSupportedException("{0} not supported".FormatWith(expression.GetType()));
            }
        }
        private static object Convert(object value, Type type)
        {
            return Expression.Lambda(Expression.Convert(Expression.Constant(value), type)).Compile().DynamicInvoke();
        }
        private static object GetValue(object instance, MemberInfo memberInfo)
        {
            switch (memberInfo.MemberType)
            {
                case MemberTypes.Field:
                    return ((FieldInfo)memberInfo).GetValue(instance);
                case MemberTypes.Method:
                    return GetValue(instance, (MethodBase)memberInfo);
                case MemberTypes.Property:
                    return GetValue(instance, (PropertyInfo)memberInfo);
                default:
                    throw new NotSupportedException("{0} not supported".FormatWith(memberInfo.MemberType));
            }
        }
        private static object GetValue(object instance, PropertyInfo propertyInfo)
        {
            return propertyInfo.GetGetMethod(true).Invoke(instance, null);
        }
        private static object GetValue(object instance, MethodBase method)
        {
            return method.IsStatic
                       ? method.Invoke(null, new[] { instance })
                       : method.Invoke(instance, null);
        }
        private static bool SupportsMethod(MethodCallExpression methodCallExpression)
        {
            return (methodCallExpression.Method.IsStatic && methodCallExpression.Arguments.Count == 1) || (methodCallExpression.Arguments.Count == 0);
        }
    }
