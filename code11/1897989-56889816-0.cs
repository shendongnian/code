    "value > 5 && value <= 10"
    var val = Expression.Parameter(typeof(int), "x");
    var body = Expression.And(
         Expression.MakeBinary(ExpressionType.GreaterThan, val, Expression.Constant(5)), 
         Expression.MakeBinary(ExpressionType.LessThanOrEqual, val, Expression.Constant(10)));
    var lambda = Expression.Lambda<Func<int, bool>>(exp, val);
    bool b = lambda.Compile().Invoke(6); //true
    bool b = lambda.Compile().Invoke(11); //false
