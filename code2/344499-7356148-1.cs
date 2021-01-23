    public static void TraceContext(string messageFormat)
    {
        Trace.WriteLine(string.Format(messageFormat, 
            new System.Diagnostics.StackFrame(1).GetMethod().Name));
    }
