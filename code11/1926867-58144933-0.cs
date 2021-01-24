    static void Main(string[] args)
    {
      if ( args.Length != 2 )
      {
        Console.WriteLine("Usage: {exename}.exe [filename 1] [filename 2]");
        Console.ReadKey();
        return;
      }
      string filename1 = args[0];
      string filename2 = args[1];
      bool checkFiles = true;
      if ( !File.Exists(filename1) )
      {
        Console.WriteLine($"{filename1} not found.");
        checkFiles = false;
      }
      if ( !File.Exists(filename2) )
      {
        Console.WriteLine($"{filename2} not found.");
        checkFiles = false;
      }
      if ( !checkFiles )
      {
        Console.ReadKey();
        return;
      }
      var lines1 = System.IO.File.ReadAllLines(args[0]).Where(l => l != "");
      var lines2 = System.IO.File.ReadAllLines(args[1]).Where(l => l != "");
      foreach ( var line in lines2 )
        if ( !lines2.Contains(line) )
          Console.WriteLine($"{filename1} does not contains: {line}");
      foreach ( var line in lines2 )
        if ( !lines2.Contains(line) )
          Console.WriteLine($"{filename1} does not contains: {line}");
      Console.ReadKey();
    }
