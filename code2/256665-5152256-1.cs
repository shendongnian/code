      var words = new List<Words>();
      string[] lines = File.ReadAllLines("myFilename");
      int weigth = 0;
      foreach( var line in lines )
      {
        if (line == "block{A}") weigth = 1;
        else if (line == "block{B}") weigth = 2;
        else if (line == "block{C}") weigth = 3;
        else words.Add( new Words{ Word = line.Replace("#",""), Weigth = weigth});
      }
