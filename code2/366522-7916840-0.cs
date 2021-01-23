    var lines = File.ReadAllLines("<CSV-File>");
    foreach (string line in lines)
    {
        var values = line.Split(new[] { line[0] }, StringSplitOptions.None);
    }
