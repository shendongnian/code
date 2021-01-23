    public delegate void DoThisWithReturn(out bool returnValue);
    public static void DoThisMethod(out bool returnValue)
    {
        returnValue = true;
    }
    public static void Start()
    {
        var delegateInstance = new DoThisWithReturn(DoThisMethod);
        bool returnValue;
        var asyncResult = delegateInstance.BeginInvoke(out returnValue, null, null);
        //Do Some Work.. 
        delegateInstance.EndInvoke(out returnValue, asyncResult);
        var valueRecievedWhenMethodDone = returnValue;
     }
