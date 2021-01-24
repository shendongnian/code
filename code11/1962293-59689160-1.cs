    string csv = @"2019-12-01T00:00:00.000Z;2019-12-10T23:59:59.999Z
    50;false;2019-12-03T15:00:12.077Z;005033971003;48;141;2019-12-03T00:00:00.000Z;2019-12-03T23:59:59.999Z
    100;false;2019-12-02T12:38:05.989Z;005740784001;80;311;2019-12-02T00:00:00.000Z;2019-12-02T23:59:59.999Z";
    
    string csvSeparator = ";";
    using (var r = ChoCSVReader.LoadText(csv)
        .WithDelimiter(csvSeparator)
        .WithCustomRecordSelector(o =>
        {
            string line = ((Tuple<long, string>)o).Item2;
    
            if (line.SplitNTrim(csvSeparator).Length == 2)
                return typeof(Headers);
            else
                return typeof(Transaction);
        })
        )
    {
        var json = ChoJSONWriter.ToTextAll(r.GroupWhile(r1 => r1.GetType() != typeof(Headers))
            .Select(g =>
            {
                Headers master = (Headers)g.First();
                master.Transactions = g.Skip(1).Cast<Transaction1>().ToList();
                return master;
            }));
        Console.WriteLine(json);
    }
