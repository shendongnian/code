    string[] linesOne = File.ReadAllLines(pathToFile1);
    string[] linesTwo = File.ReadAllLines(pathToFile2);
    
    List<string> result = new List<string>();
    for(int i=0;i<1000;i++)
    {
       result.Add(linesOne[i]);
    }
    result.AddRange(linesTwo);
    
    File.WriteAllLines(pathToFile2, result);
