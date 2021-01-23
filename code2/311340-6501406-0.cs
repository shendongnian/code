     fooEventDispatcher.GetType().GetField("FooEvent", BindingFlags.Instance | 
                                                       BindingFlags.NonPublic);
     var field = fieldInfo.GetValue(fooEventDispatcher);
     MulticastDelegate eventDelegate = (MulticastDelegate)field.GetValue(fooEventDispatcher);
     if (eventDelegate != null) // will be null if no subscribed event consumers
     {
        var delegates = eventDelegate.GetInvocationList();
     }
