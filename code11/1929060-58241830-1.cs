    try
    {
      var diff = GetDifferentRecords(before, after, "Id");
      foreach ( var item in diff )
      {
        Console.WriteLine($"Id({item.Key}) mismatch:");
        foreach ( var value in item.Value )
        {
          Console.Write($"  Column({value.Key}): ");
          Console.WriteLine($"{ value.Value.Item1.ToString()} <=> { value.Value.Item2.ToString()} ");
        }
        Console.WriteLine();
      }
    }
    catch ( Exception ex )
    {
      Console.WriteLine(ex.Message);
    }
