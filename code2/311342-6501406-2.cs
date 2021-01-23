    var fieldInfo = fooEventDispatcher.GetType().GetField(
                    "FooEvent", BindingFlags.Instance | BindingFlags.NonPublic);
    var eventDelegate = fieldInfo.GetValue(fooEventDispatcher) as MulticastDelegate;
    if (eventDelegate != null) // will be null if no subscribed event consumers
    {
       var delegates = eventDelegate.GetInvocationList();
    }
