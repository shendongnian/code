      byte[] data;
      using (MemoryStream stream = new MemoryStream())
      using (TextWriter textWriter = new StreamWriter(stream))
      using (CsvWriter csv = new CsvWriter(textWriter))
      {
        csv.Configuration.RegisterClassMap<DeviceMap>();
        csv.Configuration.ShouldQuote = (field, context) => false;
        csv.WriteRecords(values);
        textWriter.Flush();
        data = stream.ToArray();
      }
      return data;
