    static class BaseInterfaceInvocationExtension
    {
        private static readonly string invalidExpressionMessage = "Invalid expression.";
    
        public static void Base<TInterface>(this TInterface owner, Expression<Action<TInterface>> selector)
        {
            if (selector.Body is MethodCallExpression methodCallExpression)
            {
                MethodInfo methodInfo = methodCallExpression.Method;
                string name = methodInfo.DeclaringType.FullName + "." + methodInfo.Name;
                Type type = owner.GetType();
                InterfaceMapping interfaceMapping = type.GetInterfaceMap(typeof(TInterface));
                var map = interfaceMapping;
                var interfaceMethod = map.InterfaceMethods.First(info =>
                    info.Name == name);
                var functionPointer = interfaceMethod.MethodHandle.GetFunctionPointer();
    
                var x = methodCallExpression.Arguments.Select(expression =>
                {
                    if (expression is ConstantExpression constantExpression)
                    {
                        return constantExpression.Value;
                    }
                    var lambda = Expression.Lambda(Expression.Convert(expression, expression.Type));
                    return lambda.Compile().DynamicInvoke();
                }).ToArray();
                Type actionType = null;
                if (x.Length == 0)
                {
                    actionType = typeof(Action);
                }else if (x.Length == 1)
                {
                    actionType = typeof(Action<>);
                }
                else if (x.Length == 2)
                {
                    actionType = typeof(Action<,>);
                }
                var genericType = actionType.MakeGenericType(methodInfo.GetParameters().Select(t => t.ParameterType).ToArray());
                var instance = Activator.CreateInstance(genericType, owner, functionPointer);
                instance.GetType().GetMethod("Invoke").Invoke(instance, x);
            }
            else
            {
                throw new Exception(invalidExpressionMessage);
            }
        }
    }
    
    class D : IA, IB, IC
    {
        public void M(int test)
        {
           this.Base<IB>(d => d.M(test));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            D d = new D();
            d.M(12);
            Console.ReadKey();
        }
    }
