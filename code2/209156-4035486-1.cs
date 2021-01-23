    try
    {
         try
         {
            // Do something that throws  ArithmeticException
         }
         catch(ArithmeticException arithException)
         {
            // This handles the thrown exception....
            throw;  // Rethrow so the outer handler sees it too
         }
    }
    catch (Exception e)
    {
       // This gets hit as well, now, since the "inner" block rethrew the exception
    }
