    using (var reader = new CsvReader(file))
    {
        TableGuess table = new TableGuess { Name = file };
        // given: IEnumerable<string> CsvReader.Header { get; }
        table.AddColumns(reader.Header);
        string[] parts;
        while (null != (parts = reader.ReadLine()))
        {
            table.AddRow(parts);
        }
    }
