    FileStream traceLog = new FileStream("C:\\log\\Traces.svclog",FileMode.OpenOrCreate);
    
    TextWriterTraceListener myListener = new TextWriterTraceListener(traceLog);
    
    Trace.Listeners.Add(myListener);
    
    myListener.WriteLine("Sending trace information");
    
    Trace.Flush();
    
    myListener.Flush();
