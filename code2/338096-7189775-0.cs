    object handler = Activator.CreateInstance(typeof(Handler)); 
    var handlerType = handler.GetType();
    var method = handlerType.GetMethod("HandleMessage", BindingFlags.Instance | BindingFlags.Public);
    var paramType = handlerType.GetGenericArguments()[0];
    // invoke the MakeHandleMessageDelegate method dynamically with paramType as the type parameter
    // NB we're only doing this once
    Action<object> hook = (Action<object>) this.GetType().GetMethod("MakeHandleMessageDelegate")
                .MakeGenericMethod(paramType)
                .Invoke(null, new [] { handler });
            
