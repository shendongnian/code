    string searchKeyword = "eng";
    string fileName = "Some file name here";
    string[] textLines = File.ReadAllLines(fileName);
    List<string> results = new List<string>();
    foreach (string line in textLines)
    {
        if (line.Contains(searchKeyword))
        {
            results.Add(line);
        }
    }
