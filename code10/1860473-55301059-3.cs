      for (int i = 0; i < strA.Length; ++i) {
        Console.WriteLine();
        // please, note that each line can have its own length
        string[] line = strA[i];
        for (int j = 0; j < line.Length; ++j) {
          Console.Write(line[j]); // or strA[i][j]
          Console.Write(' ');     // delimiter, let it be space
        }
      } 
