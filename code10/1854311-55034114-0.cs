    void Main()
    {
        var records = new List<dynamic>();
    
        dynamic record = new ExpandoObject();
        record.Id = 1;
        record.Name = "one";
        records.Add(record);
    
        using (var writer = new StringWriter())
        using (var csv = new CsvWriter(writer))
        {
            csv.WriteRecords(records);
    
            writer.ToString().Dump();
        }
    }
