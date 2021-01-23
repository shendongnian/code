    private int _outstandingRequests = 0;
    public void InitObjectAsync()
    {
        RequestField( proxy.GetDataForField1,
                      proxy.GetDataForField1Completed, 
                      s => Field1 = s );
        RequestField( proxy.GetDataForField2, 
                      proxy.GetDataForField2Completed,
                      s => Field2 = s );
        RequestField( proxy.GetDataForField3, 
                      proxy.GetDataForField3Completed,
                      s => Field3 = s );
        // ... and so on...
    }
    // This method accepts two actions and a event handler reference.
    // It composes a lambda to perform the async field assignment and internally
    // manages the count of outstanding requests. When the count drops to zero,
    // all async requests are finished, and it raises the completed event.
    private void RequestField<T>( Action fieldInitAction, 
                                  EventHandler fieldInitCompleteEvent,
                                  Action<T> fieldSetter )
    {
        // maintain the outstanding request count...
        _outstandingRequests += 1;
        // setup event handler that responds to the field initialize complete        
        fieldInitCompleteEvent += (s,e) =>
        {
            fieldSetter( e.Result );
            _outstandingRequests -= 1;
            // when all outstanding requests finish, raise the completed event
            if( _outstandingRequests == 0 )
               RaiseInitCompleted();
        }
        // call the method that asynchronously retrieves the field value...
        fieldInitAction();
    }
    private void RaiseInitCompleted()
    {
        var initCompleted = InitObjectAsyncCompleted;
        if( initCompleted != null )
            initCompleted(this, null);
    }
