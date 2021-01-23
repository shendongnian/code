        public static Delegate BuildDynamicHandle(Type delegateType, Func<object[], object> func)
        {
            var invokeMethod = delegateType.GetMethod("Invoke");
            var parms = invokeMethod.GetParameters().Select(parm => Expression.Parameter(parm.ParameterType, parm.Name)).ToArray();
            var instance = func.Target == null ? null : Expression.Constant(func.Target);
            var converted = parms.Select(parm => Expression.Convert(parm, typeof(object)));
            var call = Expression.Call(instance, func.Method, Expression.NewArrayInit(typeof(object), converted));
            var body =
                invokeMethod.ReturnType == typeof(void) ? (Expression)call : Expression.Convert(call, invokeMethod.ReturnType);
            var expr = Expression.Lambda(delegateType, body, parms);
            return expr.Compile();
        }
