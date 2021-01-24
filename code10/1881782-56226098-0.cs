csharp
public static void Main(string[] args)
{    
    var records = new List<MyClass> {
        new MyClass {
            Property = "Title",
            MyCustoms = new List<MyCustom> {
                new MyCustom { Id = "123", Property1 = "John", Property2 = "Smith" },
                new MyCustom { Id = "456", Property1 = "Helen", Property2 = "Thomson"}
            }
        },
        new MyClass {
            Property = "AnotherProperty",
            MyCustoms = new List<MyCustom> {
                new MyCustom { Id = "123", Property1 = "Another11", Property2 = "Another12" },
                new MyCustom { Id = "456", Property1 = "Another21", Property2 = "Another22"}
            }
        }
    };
    using (var csv = new CsvWriter(Console.Out))
    {
        csv.Configuration.TypeConverterCache.AddConverter<List<MyCustom>>(new MyTypeConverter());
        csv.Configuration.HasHeaderRecord = false;
        // Get all of the ids from the first record.
        var ids = records[0].MyCustoms.Select(m => m.Id).ToList();
        csv.WriteField("Property");
        foreach (var id in ids)
        {
            csv.WriteField("Id");
            csv.WriteField($"{id}_Property1");
            csv.WriteField($"{id}_Property2");
        }
        csv.NextRecord();
        csv.WriteRecords(records);                
    }
    Console.ReadKey();
}
public class MyClass
{
    public string Property { get; set; }
    public List<MyCustom> MyCustoms {get;set;}
}
public class MyCustom
{
    public string Id { get; set; }
    public string Property1 { get; set; }
    public string Property2 { get; set; }
}
private class MyTypeConverter : DefaultTypeConverter
{
    public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
    {
        var list = (List<MyCustom>)value;
        foreach (var item in list)
        {
            row.WriteField(item.Id);
            row.WriteField(item.Property1);
            row.WriteField(item.Property2);
        }
        return null;
    }
}
