cs
public class Foo
{
    public DateTime FooDate { get; set; }
}
public static class TimeZoneAdapter
{
    public Foo Map(Foo foo)
    {
        var map = Mapper.Map(foo);
        map.FooDate = ConvertToLocalDateTime(map.FooDate);
        return map;
    }
}
// Use Map on the database objects.
var q = db.From<Foo>().Select(x => TimeZoneAdapter.Map(x));
    
List<Foo> results = db.Column<Foo>(q);
  [1]: http://docs.automapper.org/en/stable/Getting-started.html
