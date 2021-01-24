csharp
static void Main(string[] args)
{
    using (MemoryStream stream = new MemoryStream())
    using (StreamWriter writer = new StreamWriter(stream))
    using (StreamReader reader = new StreamReader(stream))
    using (CsvReader csv = new CsvReader(reader))
    {
        writer.WriteLine("Id,FirstName,LastName,MyExtraField1,MyExtraField2");
        writer.WriteLine("1,John,Doe,foo,bar");
        writer.WriteLine("2,Jane,Smith,foo2,bar2");
        writer.Flush();
        stream.Position = 0;
        csv.Read();
        csv.ReadHeader();
        var headers = csv.Context.HeaderRecord.ToList();
        csv.Configuration.RegisterClassMap(new TestClassMap(headers.Skip(3)));
        var records = csv.GetRecords<TestClass>().ToList();
    }
}
public class TestClass
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Dictionary<string, string> ExtraFields { get; set; }
}
public sealed class TestClassMap : ClassMap<TestClass>
{
    public TestClassMap(IEnumerable<string> headers)
    {
        Map(m => m.Id);
        Map(m => m.FirstName);
        Map(m => m.LastName);
        Map(m => m.ExtraFields).ConvertUsing(row => headers.ToDictionary(h => h, h => row.GetField(h)));
    }
}
