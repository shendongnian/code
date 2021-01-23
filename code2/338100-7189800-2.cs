    var type = typeof(Handler);
    var instance = Activator.CreateInstance(type);
    var method = type.GetMethod("HandleMessage", BindingFlags.Instance | BindingFlags.Public);
    var originalType = type;
    // Loop until we hit the type we want.
    while (!(type.IsGenericType) || type.GetGenericTypeDefinition() != typeof(EncasulatedMessageHandler<>))
    {
        type = type.BaseType;
        if(type == null)
            throw new ArgumentOutOfRangeException("type");
    }
    var messageType = type.GetGenericArguments()[0]; // MyMessageType
    // Use expression to create a method we can.
    var instExpr = Expression.Parameter(typeof(object), "instance");
    var paramExpr = Expression.Parameter(typeof(Message), "message");
    // (Handler)instance;
    var instCastExpr = Expression.Convert(instExpr, originalType);
    // (MyMessageType)message
    var castExpr = Expression.Convert(paramExpr, messageType); 
    // ((Handler)inst).HandleMessage((MyMessageType)message)
    var invokeExpr = Expression.Call(instCastExpr, method, castExpr); 
    // if(message is MyMessageType) ((Handler)inst).HandleMessage((MyMessageType)message);
    var ifExpr = Expression.IfThen(Expression.TypeIs(paramExpr, messageType), invokeExpr);
    // (inst, message) = { if(message is MyMessageType) ((Handler)inst).HandleMessage((MyMessageType)message); }
    var lambda = Expression.Lambda<Action<object, Message>>(ifExpr, instExpr, paramExpr);
    var compiled = lambda.Compile();
    Action<Message> hook = x => compiled(instance, x);
    hook(new MyMessageType());
