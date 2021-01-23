    static Action<T, object> MakeSetterDelegate<T>(PropertyInfo property)
    {
        MethodInfo setMethod = property.GetSetMethod();
        if (setMethod != null && setMethod.GetParameters().Length == 1)
        {
            var target = Expression.Parameter(typeof(T));
            var value = Expression.Parameter(typeof(object));
            var body = Expression.Call(target, setMethod,
                Expression.Convert(value, property.PropertyType));
            return Expression.Lambda<Action<T, object>>(body, target, value)
                .Compile();
        }
        else
        {
            return null;
        }
    }
