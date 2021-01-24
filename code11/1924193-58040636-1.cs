    //...
    var mapping = new Dictionary<Type, Type>
    {
        { typeof(MovedPermanentlyException), typeof(MovedPermanentlyExceptionHandler) }
    };
    var exceptionType = exception.GetType();
    var handlerType = mapping[exceptionType];
    var handler = Activator.CreateInstance(handlerType);
    var expression = build(exceptionType).Compile();
    var result = expression.DynamicInvoke(exception, handler);
    context.Result = (IActionResult)result;
    //...
