    var records = new List<Foo>
    {
        new Foo { Id = 1, Name = "one" },
        new Foo { Id = 1, Name = "one" }
    };
    using (var writer = new StreamWriter($"file.csv"))
    using (var csv = new CsvWriter(writer))
    {
        foreach (var record in records)
        {
            csv.WriteRecord(record);
            csv.NextRecord();
        }
    }
