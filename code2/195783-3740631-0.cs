    var exp = Expression.New(new { Name = "", Num = 0 }.GetType().GetConstructors()[0], 
                             Expression.Constant("abc", typeof(string)), 
                             Expression.Constant(123, typeof(int)));
    var lambda = LambdaExpression.Lambda(exp);
    object myObj = lambda.Compile().DynamicInvoke();
