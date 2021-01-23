     var reader = new StreamReader(File.OpenRead(@"d:\er.txt"));
          while (!reader.EndOfStream)
          {
            var line = reader.ReadLine().Trim();
            var values =  line.Split(new char[]{'|'}, StringSplitOptions.RemoveEmptyEntries);
            string[] ee = values;
    
          }
