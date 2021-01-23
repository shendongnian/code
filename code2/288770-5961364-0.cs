    public readonly SynchronizationContext mySynchronizationContext;
        
    // in ctor
    MySynchronizationContext = SynchronizationContext.Current;
    
    // in your method , to set the image:    
    SendOrPostCallback callback = _=>
    {
      image1.Source = logo;
    };
    
    mySynchronizationContext.Send(callback,null);
