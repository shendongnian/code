    var list = new List<string>();
    using ( var reader = new StreamReader(@"c:\\file.txt") )
    {
      while ( reader.Peek() >= 0 )
      {
        string line = reader.ReadLine();
        // Process data like using list.Insert(index, line);
        // Change the capacity of the List if needed for the desired index
      }
    }
    using ( var writer = new StreamWriter(@"c:\\file-new.txt", false) )
    {
      foreach ( string line in list ) 
        writer.WriteLine(line);
    }
