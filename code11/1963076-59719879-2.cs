csharp
csv.Configuration.PrepareHeaderForMatch = header => Regex.Replace(header, @"\/", string.Empty);
csv.Configuration.Delimiter = ",";
---
I must be missing something. I get the same result for `var record` whether using version 6.0.0 or 12.3.2.  I'm guessing there is more going on with your data that I'm not seeing.
Version 6.0.0
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
