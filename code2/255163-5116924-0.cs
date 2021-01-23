    XmlNode node = null;
    ParameterExpression instanceExpression = Expression.Parameter(typeof(XmlNode), "instance");
    ParameterExpression result = Expression.Parameter(typeof(object), "result");
    LabelTarget blockReturnLabel = Expression.Label(typeof(object));
    BlockExpression block = Expression.Block(
    					 typeof(object),
    					 new[] {  result },
    					 //this would normally be a function invoke
    					 Expression.Assign(result, Expression.Convert(Expression.Constant(DateTime.Now.AddSeconds(-1)), typeof(object))),
    					 Expression.Return(blockReturnLabel, result),
    					 Expression.Label(blockReturnLabel, Expression.Constant(-2, typeof(object))));
    LambdaExpression lax = Expression.Lambda<Func<XmlNode, object>>(block, instanceExpression);
    
    var left = Expression.Invoke(lax, instanceExpression);
    //false result
    //var right = Expression.Constant(5, typeof(int));  
    //true result
    var right = Expression.Constant(DateTime.Now, typeof(DateTime));
    
    var unboxedLeft = Expression.Unbox(left, right.Type);  
    var lessThanEx = Expression.LessThan(unboxedLeft, right);     
    
    var body = Expression.Condition(Expression.TypeEqual(left, right.Type),  lessThanEx,  Expression.Constant(false));  
    var expression = Expression.Lambda<Func<XmlNode, bool>>(body, instanceExpression); 
    
    bool b = expression.Compile()(node); 
    Console.WriteLine(b);
