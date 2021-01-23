    public static DelegateAccessor<TObject, TValue> GetAccessorsDelegates<TValue>(
        Expression<Func<TObject, TValue>> expression)
    {
        Func<TObject, TValue> getter = expression.Compile();
        Action<TObject, TValue> setter = null;
        ParameterExpression pValue = Expression.Parameter(typeof(TValue), "value");
        ParameterExpression pObj = expression.Parameters[0];
        if (expression.Body is MemberExpression)
        {
            Expression setterBlock = Expression.Assign(expression.Body, pValue);
            Expression<Action<TObject, TValue>> setterExpression =
                Expression.Lambda<Action<TObject, TValue>>(setterBlock, pObj, pValue);
            setter = setterExpression.Compile();
        }
        else
        {
            var getterCall = expression.Body as MethodCallExpression;
            if (getterCall != null)
            {
                var method = getterCall.Method;
                if (method.IsSpecialName && method.Name.StartsWith("get_"))
                {
                    var parameters = method.GetParameters()
                                           .Select(p => p.ParameterType)
                                           .Concat(new[] { method.ReturnType })
                                           .ToArray();
                    var setterName = "set_" + method.Name.Substring(4);
                    var setterMethod =
                        method.DeclaringType.GetMethod(setterName, parameters);
                    var setterCall = Expression.Call(
                        getterCall.Object, setterMethod,
                        getterCall.Arguments.Concat(new[] { pValue }));
                    var setterExpression =
                        Expression.Lambda<Action<TObject, TValue>>(
                            setterCall, pObj, pValue);
                    setter = setterExpression.Compile();
                }
            }
        }
        return new DelegateAccessor<TObject, TValue>(getter, setter);
    }
