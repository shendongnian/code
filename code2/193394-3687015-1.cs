Doesn't the fact that a subscribed event got fired indicate it has subscriber(s)?  So then all you would need is a list of subscribable events, which you can validate against during an intercepted call.
You can intercept a call using any AOP framework.  For instance, by using Unity Interception, you can do something like this:
    public IMethodReturn Invoke(IMethodInvocation input, 
        GetNextHandlerDelegate getNext)
    {
        // 1. assuming that you are keeping a list of method names 
        // that are being subscribed to.
        // 2. assuming that if the event is fired, then it must have
        // been subscribed to... 
        if (MyReflectedListOfSubscribedEvents.Contains(input.MethodBase.ToString())
        {
            HandleItSomeHow();
        }
        
        // process the call...
        return getNext().Invoke(input, getNext);
    }
