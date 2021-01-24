    var lines = File.ReadAllLines(fileName);
    int linesAtATime = 99;
    
    for (int i = 0; i < lines.Length; i = i + linesAtATime)
    {
        List<string> currentLinesGroup = lines.Skip(i).Take(linesAtATime).ToList();
        DoSomethingWithLines(currentLinesGroup);
    }
