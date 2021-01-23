    public void MethodName()
    {
        try
        {
            throw new Exception();
        }
        catch (Exception ex)
        {
            // Get stack trace for the exception with source file information
            var trace = new StackTrace(ex, true);
            // Get the top stack frame
            var frame = trace.GetFrame(0);
            // Get the line number from the stack frame
            var line = frame.GetFileLineNumber();
        }
    }
