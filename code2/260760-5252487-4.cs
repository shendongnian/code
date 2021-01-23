    public static class Extensions
    {
        public static void Bind<TSourceProperty, TDestinationProperty>(this INotifyPropertyChanged source, Expression<Func<TSourceProperty, TDestinationProperty>> bindExpression)
        {
            var expressionDetails = GetExpressionDetails<TSourceProperty, TDestinationProperty>(bindExpression);
            var sourcePropertyName = expressionDetails.Item1;
            var destinationObject = expressionDetails.Item2;
            var destinationPropertyName = expressionDetails.Item3;
            // Do binding here
            Console.WriteLine("{0} {1}", sourcePropertyName, destinationPropertyName);
        }
        private static Tuple<string, INotifyPropertyChanged, string> GetExpressionDetails<TSourceProperty, TDestinationProperty>(Expression<Func<TSourceProperty, TDestinationProperty>> bindExpression)
        {
            var lambda = (LambdaExpression)bindExpression;
            ParameterExpression sourceExpression = lambda.Parameters.FirstOrDefault();
            MemberExpression destinationExpression = (MemberExpression)lambda.Body;
            var memberExpression = destinationExpression.Expression as MemberExpression;
            var constantExpression = memberExpression.Expression as ConstantExpression;
            var fieldInfo = memberExpression.Member as FieldInfo;
            var destinationObject = fieldInfo.GetValue(constantExpression.Value) as INotifyPropertyChanged;
            return new Tuple<string, INotifyPropertyChanged, string>(sourceExpression.Name, destinationObject, destinationExpression.Member.Name);
        }
    }
