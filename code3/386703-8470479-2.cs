    public class MyException : Exception
    {
    }
    
    public void FunctionZero()
    {
       try
       {
          Trace.WriteLine("Function0 - Calling Function 1");
          Function1();
          Trace.WriteLine("Function0 - Function1 has returned");
       }
       catch(MyExceptionType ex)
       {
          Trace.WriteLine("Function0 - in the exception handler");
       }
    }
    
    public void Function1()
    {
        Trace.WriteLine("Function1 - Calling Function 2");
        Function2();
        Trace.WriteLine("Function1 - Function2 has returned");
    }
    
    public void Function2()
    {
        if (1==1)
        {
           // This will jump to the exception handler in function zero
           Trace.WriteLine("Function2 - throwing an exception");
           throw new MyException();
        }
    }
