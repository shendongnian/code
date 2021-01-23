    static string GetDiagnosticsInformationForCurrentFrame()
    {
        StackTrace st = new StackTrace(new StackFrame(true));        
        StackFrame sf = st.GetFrame(1); // we want the frame from where this method was called
    
        return String.Format("File: {0}, Method: {1}, Line Number: {2}, Column Number: {3}", sf.GetFileName(), sf.GetMethod().Name, sf.GetFileLineNumber(), sf.GetFileColumnNumber());
    }
...
    Debug.Assert(true, "Unexpected error occurred at " + GetDiagnosticsInformationForCurrentFrame());
