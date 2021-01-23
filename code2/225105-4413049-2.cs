    static readonly object _lockObj = new object();
    ...
    lock( _lockObj )
    { 
       ThirdPartWebService objWebService = Application["ThirdPartWebService"] As ThirdPartWebService;
       objWebService.CallThatNeedsToBeSynchronized();
    }
