    void Main()
        {
            using (var reader = new StreamReader("path\\to\\file.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.HasHeaderRecord = false;
                csv.Configuration.RegisterClassMap<FooMap>();
                csv.Configuration.RegisterClassMap<BarMap>();
                var fooRecords = new List<Foo>();
                var barRecords = new List<Bar>();
                while (csv.Read())
                {
                    switch (csv.GetField(0))
                    {
                        case "A": // Or "Test1"
                            ...
                            break;
                        case "B": // Or "TestA"
                            ...
                            break;
                        default:
                            throw new InvalidOperationException("Unknown record type.");
                    }
                }
            }
        } 
  
