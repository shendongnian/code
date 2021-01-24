    List<List<char>> lines = new List<List<char>>();
    
    string line = string.Empty;
    
    while((line = Console.ReadLine()) != null && line != string.Empty)
    {
         lines.Add(line.Select(x => x).Where(x => x != ' ').ToList());
    }
