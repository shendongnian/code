    void Export()
    {
        using (var stream = new MemoryStream())
        using (var reader = new StreamReader(stream))
        using (var writer = new StreamWriter(stream))
        using (var csv = new CsvWriter(writer))
        {
   
            foreach (var item in MasterList)
            {
                foreach (var field in item)
                {
                    csv.WriteField(field);
                }
                csv.NextRecord();
            }
            writer.Flush();
            stream.Position = 0;
    
            reader.ReadToEnd().Dump();
        }
    }
