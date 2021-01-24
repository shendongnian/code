csharp
class Program
{
    static void Main(string[] args)
    {
        var fooString = $"Id,First/Name{Environment.NewLine}1,David";
        using (var reader = new StringReader(fooString))
        using (var csv = new CsvReader(reader))
        {
            csv.Configuration.PrepareHeaderForMatch = header => Regex.Replace(header, @"\/", string.Empty);
            csv.Read();
            csv.ReadHeader();
            while (csv.Read())
            {
                var record = csv.Context.Record;
            }
        }
    }
}
public class Foo
{
    public int Id { get; set; }
    public string FirstName { get; set; }
}
Version 12.3.2
csharp
public class Program
{
    public static void Main(string[] args)
    {
        var fooString = $"Id,First/Name{Environment.NewLine}1,David";
        using (var reader = new StringReader(fooString))
        using (var csv = new CsvReader(reader))
        {
            csv.Configuration.PrepareHeaderForMatch = (header, index) => Regex.Replace(header, @"\/", string.Empty);
            csv.Read();
            csv.ReadHeader();
            while (csv.Read())
            {
                var record = csv.Context.Record;
            }
        }
    }
}
public class Foo
{
    public int Id { get; set; }
    public string FirstName { get; set; }
}
