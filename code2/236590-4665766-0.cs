    var exceptionDemoQuery =
        from file in files
        select file;
    foreach (var item in exceptionDemoQuery)
    {
      try
      {
        Console.WriteLine("Processing {0}", item);
        var n = SomeMethodThatMightThrow(item);
      }
      catch (Exception ex)
      {
        Console.WriteLine(e.Message);
      }
    }
