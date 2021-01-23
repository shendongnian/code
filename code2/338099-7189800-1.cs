    var handler = Activator.CreateInstance(typeof(Handler));
    var method = type.GetMethod("HandleMessage", BindingFlags.Instance | BindingFlags.Public);
    var hook = (Action<object>)Delegate.CreateDelegate(typeof(Action<object>), handler, method);
 
    // Then when you want to invoke it: 
    hook(new MyMessageType()); 
