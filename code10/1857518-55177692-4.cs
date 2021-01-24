    public static Expression<Func<double, double>> GetDerivative(Expression<Func<double, double>> func)
    {
        ParameterExpression x0Parameter = Expression.Parameter(typeof(double), "x0");
        ConstantExpression epsilonConstant = Expression.Constant(1e-5);
        BinaryExpression body = Expression.Divide(
            Expression.Subtract(
                Expression.Invoke(func, Expression.Add(x0Parameter, epsilonConstant)),
                Expression.Invoke(func, x0Parameter)
                ),
                epsilonConstant
            );
        return Expression.Lambda<Func<double, double>>(body, x0Parameter);
    }
