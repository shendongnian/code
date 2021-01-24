    List<string> lines = File.ReadAllLines("").ToList();
    
    for (int i = 0; i < lines.Count - 1; i++)
    {
       if (lines[i].Contains("Name"))
       {
          Console.WriteLine(lines[i]);
          Console.WriteLine(lines[i + 1]);
       }
    }
