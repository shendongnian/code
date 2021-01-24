csharp
public static void Main(string[] args)
{
    using (MemoryStream stream = new MemoryStream())
    using (StreamWriter writer = new StreamWriter(stream))
    using (StreamReader reader = new StreamReader(stream))
    using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
    {
        writer.WriteLine("MF,RefDes,MPN,Value");
        writer.WriteLine("name1,empId1,241682-27638-USD-CIGGNT ,1");
        writer.WriteLine("name2,empId2,241682-27638-USD-OCGGINT ,1");
        writer.WriteLine("name3,empId3,241942-37190-USD-GGDIV ,2");
        writer.WriteLine("name4,empId4,241942-37190-USD-CHYOF ,1");
        writer.Flush();
        stream.Position = 0;
        string[] ReferenceDesignatorAliases = { "Reference Designator", "RefDes", "Designator", "Annotation" };        
        csv.Read();
        csv.ReadHeader();
        var result = new List<string>();
        if (csv.Context.HeaderRecord.Intersect(ReferenceDesignatorAliases).Count() > 0)
        {
            while (csv.Read())
            {
                if (csv.TryGetField(csv.GetFieldIndex(ReferenceDesignatorAliases), out string value))
                {
                    result.Add(value);
                }
            }
        }
    }
    Console.ReadKey();
}
Here is another option that gets all of the columns at once and then you can split them up into the individual column lists.
csharp
public class Program
{
    public static void Main(string[] args)
    {
        List<Foo> records;
        using (MemoryStream stream = new MemoryStream())
        using (StreamWriter writer = new StreamWriter(stream))
        using (StreamReader reader = new StreamReader(stream))
        using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            writer.WriteLine("MF,RefDes,MPN,Value");
            writer.WriteLine("name1,empId1,241682-27638-USD-CIGGNT ,1");
            writer.WriteLine("name2,empId2,241682-27638-USD-OCGGINT ,1");
            writer.WriteLine("name3,empId3,241942-37190-USD-GGDIV ,2");
            writer.WriteLine("name4,empId4,241942-37190-USD-CHYOF ,1");
            writer.Flush();
            stream.Position = 0;
            csv.Configuration.RegisterClassMap<FooClassMap>();
            records = csv.GetRecords<Foo>().ToList();                
        }
        if (!records.All(r => r.ReferenceDesignator == null))
        {
            var ReferenceResult = records.Select(r => r.ReferenceDesignator).ToList();
        }
        if (!records.All(r => r.Manufacturer == null))
        {
            var ManufacturerResult = records.Select(r => r.Manufacturer).ToList();
        }
        Console.ReadKey();
    }
}
public class Foo
{
    public string ReferenceDesignator { get; set; }
    public string ManufacturersPartNumber { get; set; }
    public int? Value { get; set; }
    public string DescriptionShort { get; set; }
    public string DescriptionLong { get; set; }
    public string Manufacturer { get; set; }
    public string Dni { get; set; }
    public string DataSheet { get; set; }
}
public class FooClassMap : ClassMap<Foo>
{
    public FooClassMap()
    {
        Map(m => m.ReferenceDesignator).Optional().Name("Reference Designator", "RefDes", "Designator", "Annotation");
        Map(m => m.ManufacturersPartNumber).Optional().Name("Manufacturer's Part Number", "MPN", "PN", "part Number");
        Map(m => m.Value).Optional();
        Map(m => m.DescriptionShort).Optional().Name("Description Short", "Description");
        Map(m => m.DescriptionLong).Optional().Name("Description Long");
        Map(m => m.Manufacturer).Optional().Name("Manufacturer", "MF");
        Map(m => m.Dni).Optional().Name("DNI", "Do Not Install");
        Map(m => m.DataSheet).Optional().Name("DataSheet", "Data Sheet");
    }
}
