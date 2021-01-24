    // Create a ParameterExpression
    var parameterExpression = Expression.Parameter(typeof(Foo),"f");
    
    // Create a Constant Expression
    var formatConstant  = Expression.Constant("{0}-{1}");
    
    // Id MemberExpression
    var idMemberAccess = Expression.MakeMemberAccess(parameterExpression, typeof(Foo).GetProperty("Id"));
    // Description MemberExpression    		
    var descriptionMemberAccess = Expression.MakeMemberAccess(parameterExpression, typeof(Foo).GetProperty("Description"));
    
    // String.Format (MethodCallExpression)
    var formatMethod = Expression.Call(typeof(string),"Format",null,formatConstant,idMemberAccess,descriptionMemberAccess);
    
    // Create Lambda Expression
    var lambda = Expression.Lambda<Func<Foo,string>>(formatMethod,parameterExpression);
    
    // Create Func delegate via Compilation
    var func = lambda.Compile();
    
    // Execute Delegate 
    func(foo).Dump(); // Result "1-Test"
