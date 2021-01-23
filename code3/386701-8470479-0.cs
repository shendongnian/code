    public class MyException : Exception
    {
    }
    
    public void FunctionZero()
    {
       try
       {
          Function1();
       }
       catch(MyExceptionType ex)
       {
          
       }
    }
    
    public void Function1()
    {
        Function2();
    }
    
    public void Function2()
    {
        if (1==1)
        {
           throw new MyException();
        }
    }
