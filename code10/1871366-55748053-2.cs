      public List<FooBar> Reading()
      {
        using (var stream = new MemoryStream())
        using (var writer = new StreamWriter(stream))
        using (var reader = new StreamReader(stream))
        using (var csv = new CsvReader(reader))
        {
          writer.WriteLine(
            "FooID,FooProperty1,BarID_1,BarProperty1_1,BarProperty2_1,BarProperty3_1,BarID_2,BarProperty1_2,BarProperty2_2,BarProperty3_2");
          writer.WriteLine("1,Foo1,1,2,3,4,5,6,7,8");
          writer.Flush();
          stream.Position = 0;
          csv.Configuration.HeaderValidated = null;
          csv.Configuration.MissingFieldFound = null;
          csv.Configuration.TypeConverterCache.AddConverter<List<Bar>>(new BarListConverter());
          return csv.GetRecords<FooBar>().ToList();
        }
      }
