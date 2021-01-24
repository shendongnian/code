    var list = new List<CSVEntry>();
    while (!reader.EndOfStream)
    {
        string line = reader.ReadLine();
        list.Add(CSVEntry.Parse(line));
    }
