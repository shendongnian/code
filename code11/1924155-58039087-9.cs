    static string Test()
    {
      try
      {
        try
        {
          return "a string";
        }
        finally
        {
          Console.WriteLine("returning 1");
          Console.ReadKey();
          // no other return allowed here
        }
      }
      finally
      {
        Console.WriteLine("returning 2");
        Console.ReadKey();
        // no other return allowed here
      }
    }
