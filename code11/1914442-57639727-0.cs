    public static class ExpressionMappingHelper
    {
        public static LambdaExpression MapExpression(this IMapper mapper, LambdaExpression expression, Type sourceExpressionType, Type destExpressionType)
        {
            if (expression == null)
                return default;
            //This calls public static TDestDelegate MapExpression<TSourceDelegate, TDestDelegate>(this IMapper mapper, TSourceDelegate expression)
            //in AutoMapper.Extensions.ExpressionMapping.MapperExtensions
            return (LambdaExpression)"MapExpression".GetMapExpressionMethod().MakeGenericMethod
            (
                sourceExpressionType,
                destExpressionType
            ).Invoke(null, new object[] { mapper, expression });
        }
        private static MethodInfo GetMapExpressionMethod(this string methodName)
            => typeof(AutoMapper.Extensions.ExpressionMapping.MapperExtensions).GetMethods().Single(m => m.Name == methodName && m.GetGenericArguments().Length == 2);
    }
