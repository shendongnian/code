    public void MethodTwo()
    {
         TraceSource ts = new TraceSource("Source2");
    
         ts.TraceEvent(TraceEventType.Verbose, 0, "Called MethodTwo");
        
         // do something that causes a error
         ts.TraceEvent(TraceEventType.Error, 0, "MethodTwo threw an error");
    }
