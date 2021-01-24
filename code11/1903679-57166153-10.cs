    using (var fw = new StreamWriter("Sample32.csv", true))
    {
        using (var w = new ChoCSVWriter(fw)
            .WithFirstLineHeader()
            )
        {
            using (var r = new ChoJSONReader("Sample32.json")
                .WithJSONPath("$..Individuals[*]")
                )
            {
                w.Write(r.SelectMany(r1 => ((dynamic[])r1.Events).Select(r2 => new { r1.Id, r2.RecordId, r2.RecordType, r2.EventDate })));
            }
        }
    }
    Console.WriteLine(File.ReadAllText("Sample32.csv"));
