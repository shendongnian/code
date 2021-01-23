    public static class ObjectExtensions
    {
        public static MethodInfo GetMethod<TType, TSignature>(this TType type, Expression<Func<TType, TSignature>> methodSelector) where TType : class
        {
            var argument = ((MethodCallExpression)((UnaryExpression)methodSelector.Body).Operand).Arguments[2];
            return ((ConstantExpression)argument).Value as MethodInfo;
        }
        public static MethodInfo GetMethod<TType>(this TType type, Expression<Func<TType, Action>> methodSelector) where TType : class
        {
            return GetMethod<TType, Action>(type, methodSelector);
        }
    }
