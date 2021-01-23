    string path = "MyFile.txt";
    string[] lines = File.ReadAllLines(path);
    List<string> listOfLines = new List<string>();
    foreach(string str in lines)
    {
        listOfLines.Add(str);
    }
