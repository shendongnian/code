    var records = new List<Foo>
    {
        new Foo { Id = 1, Name = "one" },
        new Foo { Id = 1, Name = "one" },
        new Foo { Id = 1, Name = "one" },
        new Foo { Id = 1, Name = "one" },
        new Foo { Id = 1, Name = "one" },
    };
    using (var writer = new StreamWriter($"file.csv"))
    using (var csv = new CsvWriter(writer, new Configuration { HasHeaderRecord = false }))
    {
        csv.WriteRecords(records);
    }
    1;one
    1;one
    1;one
    1;one
    1;one
