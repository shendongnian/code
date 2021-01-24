    public static Expression<Func<double, double>> GetDerivative(Expression<Func<double, double>> func)
    {
        ParameterExpression x0Parameter = Expression.Parameter(typeof(double), "x0");
        ConstantExpression epsilonConstant = Expression.Constant(1e-5);
        Func<double, double> funcInstance = func.Compile();
        Type funcType = typeof(Func<double, double>);
        System.Reflection.MethodInfo invokeMethod = funcType.GetMethod("Invoke");
        ConstantExpression funcConstant = Expression.Constant(funcInstance, typeof(Func<double, double>));
        BinaryExpression body = Expression.Divide(
            Expression.Subtract(
                Expression.Call(funcConstant, invokeMethod, Expression.Add(x0Parameter, epsilonConstant)),
                Expression.Call(funcConstant, invokeMethod, x0Parameter)
                ),
                epsilonConstant
            );
        return Expression.Lambda<Func<double, double>>(body, x0Parameter);
    }
