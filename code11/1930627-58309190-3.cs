    static void Test()
    {
      var list = new List<string>();
      var indexesNew = new[] { 2, 4, 4, 1 };
      var lines = File.ReadAllLines(@"c:\\file.txt");
      foreach ( int index in indexesNew )
        list.Add(lines[index - 1]);
      File.WriteAllLines(@"c:\\file-new.txt", lines.ToArray());
      lines = File.ReadAllLines(@"c:\\file-new.txt");
      foreach ( var item in lines )
        Console.WriteLine(item);
      Console.WriteLine();
    }
