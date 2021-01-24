    public static Class1.testD2 SetTestD2(System.Reflection.MethodInfo method)
    {
      ParameterExpression param = Expression.Parameter(typeof(object[]), "args"); // Expression.Parameter(typeof(object[]), "args");
      BinaryExpression[] byExp=null;
      Expression[] argsExp = GetArgExp(method.GetParameters(), param, ref byExp);
    
      ParameterExpression xxx = Expression.Variable(typeof(int));
      ParameterExpression yyy = Expression.Variable(typeof(string));
    
      var blockExp =
          Expression.Block( new[] { xxx, yyy } //variables
          , Expression.Assign(xxx, argsExp[0]) 
          , Expression.Assign(yyy, argsExp[1])
          , Expression.Call(method, xxx, yyy)
          , Expression.Assign(Expression.ArrayAccess(param, Expression.Constant(0)), Expression.Convert(xxx, typeof(object))) //change input param array
          ) ;
    
      LambdaExpression result = Expression.Lambda(typeof(testD2), blockExp, param); 
      return (testD2)result.Compile();
    }
