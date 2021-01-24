csharp
public class Program
{
    public static void Main(string[] args)
    {
        var records = new List<Record>
        {
            new Record { Id = 1, Name = "Record1", Collection = new List<string>{"First", "Second", "Third"}},
            new Record { Id = 2, Name = "Record2", Collection = new List<string>{"First", "Second"}},
        };
        using (var csv = new CsvWriter(Console.Out))
        {
            csv.Configuration.HasHeaderRecord = false;
            csv.Configuration.RegisterClassMap<RecordMap>();
            csv.WriteRecords(records);
        }
        Console.ReadKey();
    }
}
public class RecordMap : ClassMap<Record>
{
    public RecordMap()
    {
        Map(m => m.Id);
        Map(m => m.Name);
        Map(m => m.Collection).Index(3);
    }
}
public class Record
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<string> Collection { get; set; }
}
Outputs:
1,Record1,First,Second,Third
2,Record2,First,Second
If you know the max number of items in the Collection, you can also set an end index and have `CsvHelper` create the headings for each collection item.
csharp
public class RecordMap : ClassMap<Record>
{
    public RecordMap()
    {
        Map(m => m.Id);
        Map(m => m.Name);
        Map(m => m.Collection).Index(3, 5);
    }
}
Remove `csv.Configuration.HasHeaderRecord = false;` and now it will also print the header record for you.
Outputs:
Id,Name,Collection1,Collection2,Collection3
1,Record1,First,Second,Third
2,Record2,First,Second
