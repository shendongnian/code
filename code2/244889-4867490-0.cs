    using System;
    namespace Code
    {
    class Test
    {
      public static int i;
      static Test()
      {
        i = 10;
        Console.WriteLine(i);
      }
      static void Main()
      {
        Console.WriteLine(Test.i);
        Console.Read();
      }
    }
    }
