    var lines = new Dictionary<int, string>();
    var indexesNew = new HashSet<int> { 2, 4, 4, 1 };
    using ( var reader = new StreamReader(@"c:\\file.txt") )
      for ( int index = 1; index <= indexesNew.Count; index++ )
        if ( reader.Peek() >= 0 )
        {
          string line = reader.ReadLine();
          if ( !lines.ContainsKey(index) && indexesNew.Contains(index) )
            lines[index] = line;
        }
    using ( var writer = new StreamWriter(@"c:\\file-new.txt", false) )
      foreach ( int index in indexesNew )
        if ( lines.ContainsKey(index) )
          writer.WriteLine(lines[index]);
