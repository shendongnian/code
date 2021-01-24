csharp
public static void Main(string[] args)
{    
    var records = new List<Foo> { new Foo { Id = 1, Name = "" }, new Foo { Id = 2 } };
    using (var csv = new CsvWriter(Console.Out))
    {        
        var shouldIgnoreName = records.All(foo => string.IsNullOrEmpty(foo.Name));
        var classMap = new DefaultClassMap<Foo>();
        classMap.AutoMap();
        classMap.Map(m => m.Name).Ignore(shouldIgnoreName);
        csv.Configuration.RegisterClassMap(classMap);
        csv.WriteRecords(records);
    }
    Console.ReadKey();
}
public class Foo
{
    public int Id { get; set; }
    public string Name { get; set; }
}        
