    public override IMessage Invoke(IMessage message)
    {
        IMethodMessage methodMessage = message as IMethodMessage;
        if (methodMessage != null)
        {
             MethodBase method = methodMessage.MethodBase;
             Type[] genericArgs = method.GetGenericArguments();
             ...
        }
        else
        {
            // not a method call
        }
    }
