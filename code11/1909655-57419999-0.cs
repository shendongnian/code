    string csv = @"Endereço_4, Endereço_5
    1, 11
    2, 22";
    StringBuilder output = new StringBuilder();
    using (var r = ChoCSVReader.LoadText(csv).WithFirstLineHeader())
    {
        using (var w = new ChoJSONWriter(output))
            w.Write(r);
    }
    
    Console.WriteLine(output);
