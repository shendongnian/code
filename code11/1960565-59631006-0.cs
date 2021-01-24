csharp
public class Program
{
    public static void Main(string[] args)
    {
        var connection = "Data Source=ServerName;Initial Catalog=MyDatabase;Integrated Security=true";
        var sql = @"
SELECT 
  COLUMN_NAME as ColumnName, 
  CHARACTER_MAXIMUM_LENGTH as CharacterMaximumLength 
FROM 
  INFORMATION_SCHEMA.COLUMNS 
WHERE 
  TABLE_NAME = @TableName AND CHARACTER_MAXIMUM_LENGTH IS NOT NULL";
        List<MaxLength> maxLengths;
        using (var db = new SqlConnection(connection))
        {
            maxLengths = db.Query<MaxLength>(sql, new { TableName = "MyClassExample" }).AsList();
        }
        var records = new List<MyClassExample>
        {
            new MyClassExample {Id = 1, PropertyName = "First"},
            new MyClassExample {Id = 2, PropertyName = "Second is certainly longer than the 50 characters maximum length."}
        };
        using (var csv = new CsvWriter(Console.Out))
        {
            var classMap = new DefaultClassMap<MyClassExample>();
            classMap.AutoMap(); 
            classMap.RegisterMaxLengths(maxLengths);
            csv.Configuration.RegisterClassMap(classMap);
            csv.WriteRecords(records);
        }
        Console.ReadLine();
    }
}
public class MyClassExample
{
    public int Id { get; set; }
    public string PropertyName { get; set; }
}
public class MaxLengthConverter : StringConverter
{
    private readonly int _maxLength = 0;
    public MaxLengthConverter(int maxLength)
    {
        _maxLength = maxLength;
    }
    public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
    {
        if (value is string text)
            if (text.Length > _maxLength)
            {
                var message =   $"The text with length {text.Length} exceeds the maximum allowed length of {_maxLength}.\r\n" +
                                $"    Text: '{text}'\r\n" +
                                $"    Property: {memberMapData.Member?.Name}\r\n" +
                                $"    TypeConverter: '{memberMapData.TypeConverter?.GetType().FullName}'";
                throw new TypeConverterException(this, memberMapData, value, row.Context, message);
            }
        return base.ConvertToString(value, row, memberMapData);
    }
}
public class MaxLength
{
    public string ColumnName { get; set; }
    public int CharacterMaximumLength { get; set; }
}
public static class CsvHelpExtensions
{
    public static void RegisterMaxLengths<T>(this ClassMap<T> map, IEnumerable<MaxLength> maxLengths)
    {
        foreach (var property in typeof(T).GetProperties())
        {
            var maxLength = maxLengths.Where(info => info.ColumnName.ToLower() == property.Name.ToLower()).FirstOrDefault();
            if (maxLength != null)
                map.Map(typeof(T), property, true).TypeConverter(new MaxLengthConverter(maxLength.CharacterMaximumLength));
        }
    }
}
