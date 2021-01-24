    var seiten = new List<string[]>();
    var allLines = File.ReadAllLines(oFDOpenDatei.FileName));
    int consumedLines = 0;
    while (consumedLines < allLines.Length)
    {
        var group = allLines.Skip(consumedLines).TakeWhile(s => s != "(-*-)").ToArray();
        if (group.Any()) seiten.Add(group);
        consumedLines += group.Length + 1;
    }
