csharp
using (var csv = new CsvWriter(Console.Out))
{
    var records = new List<Foo>
    {
        new Foo { Id = 1, Name = "First, Record" },
        new Foo { Id = 2, Name = "Second \"Record" },
        new Foo { Id = 3, Name = "" },
        new Foo { Id = 4 }
    };
    csv.Configuration.ShouldQuote = (field, context) => false;
    csv.Configuration.TypeConverterCache.AddConverter<string>(new QuoteStringConverter());
    csv.WriteRecords(records);
}
public class Foo
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class QuoteStringConverter : StringConverter
{
    public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
    {
        if (value == null)
            return "\"\"";
        return "\"" + ((string)value).Replace("\"", "\"\"") + "\"";
    }
}
