    LambdaExpression build(Type exceptionType) {
        var type = typeof(ISaberpsicologiaExceptionHandler<>);
        var genericType = type.MakeGenericType(exceptionType); //ISaberpsicologiaExceptionHandler<MyException>
        var handle = genericType.GetMethod("Result", new[] { exceptionType });
        var func = typeof(Func<,,>);
        var delegateType = func.MakeGenericType(typeof(Exception), genericType, typeof(ActionResult));
        //Intension is to create the following expression:
        // Func<Exception,ISaberpsicologiaExceptionHandler<MyException>, ActionResult> function =
        // (exception, handler) => (new handler()).Result((MyException)exception);
        // exception =>
        var exception = Expression.Parameter(typeof(Exception), "exception");
        // handler =>
        var handler = Expression.Parameter(genericType, "handler");
        // (MyException)exception
        var cast = Expression.Convert(exception, exceptionType);
        // handler.Result((MyException)exception)
        var body = Expression.Call(handler, handle, cast);            
        //Func<TException, THandler<MyException>, ActionResult> (exception, handler) => 
        //  handler.Result((MyException)exception)
        var expression = Expression.Lambda(delegateType, body, exception, handler);
        return expression;
    }
