csharp
public static void Main(string[] args)
{
    var paths = new List<string> { "path1", "path2", "path3" };
    List<Object> newObject = new List<Object> {
        new Object
        {
            Name = "NameValue",
            ID = "IdValue",
            Date = DateTime.Now,
            Number = 12345,
            FilePaths = paths,
            Messages = "MessagesValue"
        }
    };
    using (var csv = new CsvWriter(outputStream))
    {
        csv.Configuration.RegisterClassMap(new ObjectMap());
        csv.WriteRecords(newObject);
    }
}
public class ObjectMap : ClassMap<Object>
{
    public ObjectMap()
    {
        AutoMap();
        Map(m => m.FilePaths).TypeConverter<ListStringConverter>();
    }
}
private class ListStringConverter : StringConverter
{
    public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
    {
        var list = (List<string>)value;
        var commaSeparated = string.Join(";", list);
        return base.ConvertToString(commaSeparated, row, memberMapData);
    }
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        var list = text.Split(';').ToList();
        return list;
    }
}
public class Object
{
    public string Name { get; set; }
    public string ID { get; set; }
    public DateTime Date { get; set; }
    public long Number { get; set; }
    public List<String> FilePaths { get; set; }
    public string Messages { get; set; }
}
