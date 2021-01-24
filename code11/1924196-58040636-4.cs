     LambdaExpression buildHandlerDelegate(Type exceptionType, Type handlerType) {
        var type = typeof(ISaberpsicologiaExceptionHandler<>);
        var genericType = type.MakeGenericType(exceptionType); //ISaberpsicologiaExceptionHandler<MyException>
        var handle = genericType.GetMethod("Result", new[] { exceptionType });
        var func = typeof(Func<,>);
        var delegateType = func.MakeGenericType(typeof(Exception), typeof(ActionResult));
        //Intension is to create the following expression:
        // Func<Exception, ActionResult> function = 
        // (exception) => (new handler()).Result((MyException)exception);
        // exception =>
        var exception = Expression.Parameter(typeof(Exception), "exception");
        // new handler()
        var newHandler = Expression.New(handlerType);
        // (MyException)exception
        var cast = Expression.Convert(exception, exceptionType);
        // (new handler()).Result((MyException)exception)
        var body = Expression.Call(newHandler, handle, cast);
        //Func<TException, ActionResult> (exception) => 
        //  (new handler()).Result((MyException)exception)
        var expression = Expression.Lambda(delegateType, body, exception);
        return expression;
    }
