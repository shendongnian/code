    Console.WriteLine("Real 1");
    using (new DynamicConsole("Foo.txt"))
    {
      Console.WriteLine("Moo");
      using (new DynamicConsole("Bar.txt"))
      {
        Console.WriteLine("Ork");
      }
      Console.WriteLine("Bar");
    }
    Console.WriteLine("Real 2");
