    var lines = new Dictionary<int, string>();
    var indexesProcessed = new HashSet<int>();
    var indexesNew = new List<int> { 2, 4, 4, 1 };
    using ( var reader = new StreamReader(@"c:\\file.txt") )
      for ( int index = 1; index <= indexesNew.Count; index++ )
        if ( reader.Peek() >= 0 )
        {
          string line = reader.ReadLine();
          if ( indexesNew.Contains(index) && !indexesProcessed.Contains(index) )
          {
            lines[index] = line;
            indexesProcessed.Add(index);
          }
        }
    using ( var writer = new StreamWriter(@"c:\\file-new.txt", false) )
      foreach ( int index in indexesNew )
        if ( indexesProcessed.Contains(index) )
          writer.WriteLine(lines[index]);
