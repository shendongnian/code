    AsyncLineWriter lineWriter = new AsyncLineWriter();
    Object myState = new Object();
    object[] state = new object[2];
    state[0] = lineWriter;
    state[1] = myState;
    object callbackState = null;
    AsyncCallback callback = (r) =>
        {  
            Object[] arr = (Object[])r.AsyncState;
            LineWriter lw = (LineWriter)arr[0];
            Object st = arr[1];
            callbackState = st;
            lw.EndWriteLine(r);
        };
    // Act
    IAsyncResult asyncResult = lineWriter.BeginWriteLine("test", callback, state);
    asyncResult.AsyncWaitHandle.WaitOne();
    //Assert
    Assert.AreSame(myState, callbackState);
