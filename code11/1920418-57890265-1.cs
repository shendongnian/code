    if (args[0] == "prog1")
    {
        int state = 0;
    
        // ReadLines - we don't have to read the entire file into a collection
        foreach (var line in File.ReadLines(filename)) {
          if (state == 0) {
            if (line.Contains("Name")) { 
              state = 1;
              Console.WriteLine(line); 
            }
          }
          else if (state == 1) {
            state = 0;
            Console.WriteLine(line); 
          }
        }
    }
