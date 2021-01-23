    var method = typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) });
    var callExpression = Expression.Call(null, method, Expression.Constant("Hello   World"));
    var expression = Expression.Lambda<Action>(callExpression);  
    // Now let's try to inspect 'expression'
   
    var body = expression.Body as MethodCallExpression;
    
    if (body != null)
    {
        Console.WriteLine("Expn's body is a method-call expn.");    
        Console.WriteLine("...that calls:" + body.Method.Name);
    
        var args = body.Arguments;
    
        if (args.Any())
        {
            Console.WriteLine("The call has arguments.");    
            var firstArg = args.First() as ConstantExpression;
    
            if (firstArg != null)
            {
                Console.WriteLine("The first argument is a constant expn.");
                Console.WriteLine("...with value " + firstArg.Value);
            }
        }
    }
