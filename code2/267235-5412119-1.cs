    [Conditional("DEBUG")]
    public static void Print(string message){
        TraceInternal.WriteLine(message);
    }
    
    [Conditional("DEBUG")]
    public static void WriteLine(string message){
        TraceInternal.WriteLine(message);
    }
    
    [Conditional("DEBUG")]
    public static void WriteLine(object value)
    {
        TraceInternal.WriteLine(value);
    }
 
