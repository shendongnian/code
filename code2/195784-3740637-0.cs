    Type t = new { Name = "abc", Num = 123 }.GetType();
    var exp = Expression.New(t.GetConstructor(new[] { typeof(string), typeof(int)}),
              Expression.Constant("def"), Expression.Constant(456));
    var lambda = LambdaExpression.Lambda(exp);
    object myObj = lambda.Compile().DynamicInvoke();
    Console.WriteLine(myObj);
