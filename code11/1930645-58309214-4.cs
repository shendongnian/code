    List<int> lineNumbers = new List<int> { 2, 4, 4, 1 };
    Dictionary<int, string> lines = new Dictionary<int, string>();
    using ( StreamReader sr = new StreamReader(inputFile) )
      for ( int currentLine = 1; currentLine <= lineNumbers.Count; currentLine++ )
        if ( lineNumbers.Contains(currentLine) )
          lines[currentLine] = sr.ReadLine();
        else
          sr.ReadLine();
    using ( StreamWriter sw = new StreamWriter(outputFile) )
      foreach ( var line in lineNumbers )
        sw.WriteLine(lines[line]);
