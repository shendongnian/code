    string searchKeyword = "eng";
    string fileName = "Some file name here";
    string[] textLines = File.ReadAllLines(fileName);
    ArrayList results = new ArrayList();
    foreach (string line in textLines)
    {
        if (line.Contains(searchKeyword))
        {
            results.Add(line);
        }
    }
