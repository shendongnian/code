      public string Writing(List<FooBar> data)
      {
        using (var stream = new MemoryStream())
        using (var writer = new StreamWriter(stream))
        using (var reader = new StreamReader(stream))
        using (var csv = new CsvWriter(writer))
        {
          csv.Configuration.HasHeaderRecord = false;
          csv.Configuration.TypeConverterCache.AddConverter<List<Bar>>(new BarListConverter());
          csv.WriteRecords(data);
          writer.Flush();
          stream.Position = 0;
          return reader.ReadToEnd();
        }
