    void Main()
    {
        var records = new List<Foo>
        {
            new Foo { Id = 1, Name = "one" },
            new Foo { Id = 2, Name = "two" },
        };
        using (var writer = new StringWriter())
        using (var csv = new CsvWriter(writer, CultureInfo.CurrentCulture))
        {
            csv.Configuration.RegisterClassMap<FooMap>();
    
            csv.WriteField("Title:");
            csv.WriteField("Title");
            csv.NextRecord();
    
            csv.WriteRecords(records);
            writer.ToString().Dump();
        }
    }
    
    public class Foo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class FooMap : ClassMap<Foo>
    {
        public FooMap()
        {
            Map(m => m.Id).Index(0).Name("S.No.");
            Map(m => m.Name).Index(1);
        }
    }
