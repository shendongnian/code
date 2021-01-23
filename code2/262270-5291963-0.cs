    public static class Utils
    {
            public static Action<T, object> MethodDelegateFor<T>(MethodInfo method)
            {
                var parameter = method.GetParameters().Single();
                var instance = Expression.Parameter(typeof(T), "instance");
                var argument = Expression.Parameter(typeof(object), "argument");
                var methodCall = Expression.Call(
                    instance,
                    method,
                    Expression.Convert(argument, parameter.ParameterType)
                    );
                return Expression.Lambda<Action<T, object>>(
                    methodCall,
                    instance, argument
                    ).Compile();
            }
    
            public static Action<T, object> PropertySetterFor<T>(PropertyInfo property)
            {
                return MethodDelegateFor<T>(property.GetSetMethod());
            }
    }
