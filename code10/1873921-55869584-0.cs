csharp
public static void Main(string[] args)
{
    using (MemoryStream stream = new MemoryStream())
    using (StreamWriter writer = new StreamWriter(stream))
    using (StreamReader reader = new StreamReader(stream))
    using (CsvReader csv = new CsvReader(reader))
    {
        writer.WriteLine("trip_id,arrival_time,departure_time");
        writer.WriteLine("101,08:00:00,09:00:00");
        writer.Flush();
        stream.Position = 0;
        var records = csv.GetRecords<Foo>().ToList();
        Console.ReadKey();
    }
}
public class Foo
{
    public int trip_id { get; set; }
    public TimeSpan arrival_time { get; set; }
    public TimeSpan departure_time { get; set; }
}
If you want to do something beyond the default, then you can create your own converter and use it.
csharp
public static void Main(string[] args)
{
    using (MemoryStream stream = new MemoryStream())
    using (StreamWriter writer = new StreamWriter(stream))
    using (StreamReader reader = new StreamReader(stream))
    using (CsvReader csv = new CsvReader(reader))
    {
        writer.WriteLine("trip_id,arrival_time,departure_time");
        writer.WriteLine("101,08:00:00,09:00:00");
        writer.Flush();
        stream.Position = 0;
        csv.Configuration.RegisterClassMap<FooMap>();
        var records = csv.GetRecords<Foo>().ToList();
        Console.ReadKey();
    }
}
public class Add30SecondsConverter : TimeSpanConverter
{
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        var timespan = (TimeSpan)base.ConvertFromString(text, row, memberMapData);
        return timespan.Add(new TimeSpan(0, 0, 30));
    }
}
public class FooMap : ClassMap<Foo>
{
    public FooMap()
    {
        Map(m => m.trip_id);
        Map(m => m.arrival_time).TypeConverter<Add30SecondsConverter>();
        Map(m => m.departure_time);
    }
}
public class Foo
{
    public int trip_id { get; set; }
    public TimeSpan arrival_time { get; set; }
    public TimeSpan departure_time { get; set; }
}
