    var seiten = new List<string>();
    var allLines = File.ReadAllLines(oFDOpenDatei.FileName);
    int consumedLines = 0;
    while (consumedLines < allLines.Length)
    {
        var group = allLines.Skip(consumedLines).TakeWhile(s => s != "(-*-)").ToArray();
        if (group.Any()) seiten.Add(string.Join(Environment.NewLine, group));
        consumedLines += group.Length + 1;
    }
    
    rTBA.Text = seiten[0];
    rTBB.Text = seiten[1];
