    try
    {
       // Code that might throw.
    }
    catch (Exception e)
    {
        if(e is Exception1 || e is Exception2 || e is ExceptionN) 
        {
             // Common handling code here.
        }
        else throw; // Can't handle, rethrow.
    }
