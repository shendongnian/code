    static void Test()
    {
      var testing = File.ReadAllLines(@"c:\Testing.txt");
      string[,] result = new string[testing.Length, 2];
      int i = 0, j = 0;
      foreach ( var line in testing )
      {
        j = 0;
        foreach ( var col in line.Trim().Split(',') )
          result[i, j++] = col.Trim();
        i++;
      }
      for ( int index = result.GetLowerBound(0); index < result.GetUpperBound(0); index++ )
          Console.WriteLine($"Code = {result[index, 0]}, Name = {result[index,1]}");
    }
