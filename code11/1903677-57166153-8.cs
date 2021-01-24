    StringBuilder msg = new StringBuilder();
    
    using (var w = new ChoCSVWriter(msg)
        .WithFirstLineHeader()
        )
    {
        using (var r = new ChoJSONReader("Sample32.json")
            .WithJSONPath("$..Events[*]")
            )
        {
            w.Write(r);
        }
    }
    Console.WriteLine(msg.ToString());
