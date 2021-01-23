    Exception exc = null;
    using (var x = new object())
    {
        try
        {
           // do something x, that causes an exception to be thrown
        }
        catch(Exception ex) { exc = ex; } // bubble-up the exception
     }
     if(exc != null) { throw exc; } // throw the exception if it is not null
