csharp
public class Program
{
    public static void Main(string[] args)
    {
        using (MemoryStream stream = new MemoryStream())
        using (StreamWriter writer = new StreamWriter(stream))
        using (StreamReader reader = new StreamReader(stream))
        using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            writer.WriteLine("Id,Company");
            writer.WriteLine("1,\"=HYPERLINK(\"\"https://app.redflagalert.net/search/company/00975699/\"\",\"\"CHILTERN HILLS MINERAL WATER LIMITED\"\")\"");
            writer.Flush();
            stream.Position = 0;
            csv.Configuration.RegisterClassMap<FooClassMap>();
            var records = csv.GetRecords<Foo>().ToList();
        }
        Console.ReadKey();
    }
}
public class FooClassMap : ClassMap<Foo>
{
    public FooClassMap()
    {
        Map(m => m.Id);
        Map(m => m.CompanyLink).ConvertUsing(row => row[1].Split(',')[0]);
        Map(m => m.Company).ConvertUsing(row => row[1].Split(',')[1]);
    }
}
public class Foo
{
    public int Id { get; set; }
    public string CompanyLink { get; set; }
    public string Company { get; set; }
}
