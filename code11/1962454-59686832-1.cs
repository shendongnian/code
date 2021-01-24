csharp
public class Program
{
    public static void Main(string[] args)
    {
        var records = new List<Foo> { new Foo { Id = 1, BeginDate = DateTime.Now } };
        using(var csv = new CsvWriter(Console.Out))
        {
            csv.Configuration.RegisterClassMap<FooMap>();
            csv.WriteRecords(records);
        }
        Console.ReadLine();
    }
}
public class Foo
{
    public int Id { get; set; }
    public DateTime BeginDate { get; set; }
}
public class FooMap : ClassMap<Foo>
{
    public FooMap()
    {
        AutoMap();
        Map(m => m.BeginDate).Name("Delivery Begin Date").Index(0).ConvertUsing(x => x.BeginDate.ToShortDateString());
    }
}
