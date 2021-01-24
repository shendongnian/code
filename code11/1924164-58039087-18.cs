    static string Test()
    {
      try
      {
        try
        {
          return "a string"; // the string is pushed in the stack here
        }
        finally
        {
          Console.WriteLine("1");
          Console.ReadKey();
          // no other return allowed here
        }
      }
      finally
      {
        Console.WriteLine("2");
        Console.ReadKey();
        // no other return allowed here
      }
    }
    // The method that calls Test() next pop the stack to retreive the string
