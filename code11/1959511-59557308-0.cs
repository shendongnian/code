    StringBuilder csv = new StringBuilder();
    
    using (var r = ChoJSONReader.LoadText(json)
        .WithJSONPath("$..getUsers[*]")
        )
    {
        using (var w = new ChoCSVWriter(csv)
            .WithFirstLineHeader()
            .Configure(c => c.MaxScanRows = 2)
            .Configure(c => c.ThrowAndStopOnMissingField = false)
            )
        {
            w.Write(r);
        }
    }
    
    Console.WriteLine(csv.ToString());
