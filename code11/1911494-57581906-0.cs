csharp
public static void Main(string[] args)
{
    var records = new List<Foo>
    {
        new Foo { FirstName = "FName1", LastName = "LName1", Gender = "Male"},
        new Foo { FirstName = "FName2", LastName = "LName2", Gender = "Female"},
        new Foo { FirstName = "FName3", LastName = "LName3"},
    };
    using (var csv = new CsvWriter(Console.Out))
    {
        var map = new FooMap();
        var properties = typeof(Foo).GetProperties();
        foreach (var property in properties)
        {
            if(records.All(foo => property.GetValue(foo) == null))
            {
                map.Map(typeof(Foo), property).Ignore();
            }
        }
        csv.Configuration.RegisterClassMap(map);
        csv.WriteRecords(records);
    }
    Console.ReadKey();
}
public class Foo
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
}
public class FooMap : ClassMap<Foo>
{
    public FooMap()
    {
        Map(m => m.FirstName).Name("First Name");
        Map(m => m.MiddleName).Name("Middle Name");
        Map(m => m.LastName).Name("Last Name");
        Map(m => m.Gender);
    }
}
And if you didn't want to create a separate class map, just replace `FooMap` with `DefaultClassMap<Foo>` and use `AutoMap`.
csharp
var map = new DefaultClassMap<Foo>();
map.AutoMap();
