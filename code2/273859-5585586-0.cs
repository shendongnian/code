    Class Program
    {
      public static void Main()
      {
        ThreadPool.QueueUserWorkItem(() => f(a));
        ThreadPool.QueueUserWorkItem(() => g(b));
    
        while(true)
        {
          if(Console.Readline() == "something")
            //do something
        }
      }
      private static void f (param)
      {
        while(abc)
          //do work
      }
    }
