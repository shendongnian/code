    using System;
    class MyException : Exception
    {
      public MyException(string str)
      {
        Console.WriteLine("User defined exception");
      }
    }
    class MyClass
    {
      public static void Main()
      {
        try
        {
          throw new MyException("user exception");
        }
        catch(Exception e)
        {
          Console.WriteLine("Exception caught here" + e.ToString());
        }      
      }
    }
