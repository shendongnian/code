    static void Test()
    {
      RowObject r0 = new RowObject(3);
      r0[0] = 7250.345;
      r0[1] = null;
      r0[2] = 64.742;
      RowObject r1 = new RowObject(3);
      r1[0] = null;
      r1[1] = null;
      r1[2] = null;
      RowObject r2 = new RowObject(3);
      r2[0] = 7250.345;
      r2[1] = 1000.0;
      r2[2] = 64.742;
      Action<RowObject, string> test = (rowobject, name) =>
      {
        var sum = rowobject.Sum(); // any null value is evaluated as 0
        Console.WriteLine(name + ".Sum() = " + sum);
        if ( rowobject.Any(v => v != null) )
          Console.WriteLine(name + " contains at least a not null value");
        if ( rowobject.Any(v => v == null) )
          Console.WriteLine(name + " contains at least one null value");
        if ( rowobject.All(v => v != null) )
          Console.WriteLine(name + " contains no null value");
        if ( rowobject.All(v => v == null) )
          Console.WriteLine(name + " contains only null value");
      };
      test(r0, "r0");
      Console.WriteLine();
      test(r1, "r1");
      Console.WriteLine();
      test(r2, "r2");
    }
