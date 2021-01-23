    MethodInfo methodOn_TestClick = this.GetType().GetMethod("TestClick", new Type[] { typeof(object), typeof(EventArgs));
    
    Delegate handler = Delegate.CreateDelegate(
        event_DomClick.EventHandlerType, this, methodOn_TestClick, true); // note the change here
    
    eventClick.AddEventHandler(obj, handler);
