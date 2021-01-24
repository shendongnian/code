    var list = new List<string>();
    using ( var reader = new StreamReader(@"c:\\file.txt") )
    {
      while ( reader.Peek() >= 0 )
      {
        string line = reader.ReadLine();
        // Process data
      }
    }
    using ( var writer = new StreamWriter(@"c:\\file-new.txt", false) )
    {
      foreach ( string line in list ) 
        writer.WriteLine(line);
    }
