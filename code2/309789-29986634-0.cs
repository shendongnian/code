    // get events as observable 
    var events = Observable.FromEvent<MouseButtonEventHandler, MouseEventArgs>(
        handler => MouseUp += handler, handler => MouseUp -= handler);
    
    // subscribe to events
    var subscription = events.Subscribe(args => OnMouseUp()));
    
    // always dispose subscriptions! 
    subscription.Dispose(); 
