     try
     {
         object result = processClass.InvokeMethod("Create", methodArgs);
     }
     catch (Exception e)
     {
         // Here I was hoping to get an error code.
         if (ExceptionContainsErrorCode(e, 10004))
         {
             // Execute desired actions
         }
     }
...
    private bool ExceptionContainsErrorCode(Exception e, int ErrorCode)
    {
        Win32Exception winEx = e as Win32Exception;
        if (winEx != null && ErrorCode == winEx.ErrorCode) 
            return true;
    
        if (e.InnerException != null) 
            return ExceptionContainsErrorCode(e.InnerException, ErrorCode);
    
        return false;
    }
