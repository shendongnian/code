    string[] files = Directory.GetFiles(directory);
    foreach(string filename in files)
    {
       if (Path.GetExtension(filename) != ".txt")
          continue;
       string[] lines = System.IO.File.ReadAllLines(filename);
       foreach (string line in lines)
       {
          process(line);
       }
    }
