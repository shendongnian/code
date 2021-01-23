    var queue = new Queue<Expression>();
    var arguments = Expression.Parameter(typeof(string []), "args");
    queue.Enqueue(Expression.Call(typeof(Console).GetMethod("WriteLine", new Type [] { })));
    var block = Expression.Block(queue);
    var lambda = Expression.Lambda<Func<string [], int>>(block, new ParameterExpression [] { arguments });
    lambda.CompileToMethod(builderMethod);
    // builderMethod is a MethodBuilder instance created earlier.
