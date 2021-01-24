var x = new { UpdatedAtUtc = DateTime.UtcNow };
Console.WriteLine(JsonSerializer.Serialize(x));
produces
{"UpdatedAtUtc":"2019-11-06T02:41:45.4610928Z"}
# 2. Use your converter
var x = new { UpdatedAt = DateTime.Now };
JsonSerializerOptions options = new JsonSerializerOptions();
options.Converters.Add(new DateTimeConverter());
Console.WriteLine(JsonSerializer.Serialize(x, options));
{"UpdatedAt":"2019-11-06T12:50:48.711255"}
# 3. Use `DateTimeKind.Unspecified`
class X { public DateTime UpdatedAt {get;set;}}
public static void Main()
{
    var localNow = DateTime.Now;
    var x = new X{ UpdatedAt = localNow };
    Console.WriteLine(JsonSerializer.Serialize(x));
    x.UpdatedAt = DateTime.SpecifyKind(localNow, DateTimeKind.Unspecified);
    Console.WriteLine(JsonSerializer.Serialize(x));
produces
{"UpdatedAt":"2019-11-06T12:33:56.2598121+10:00"}
{"UpdatedAt":"2019-11-06T12:33:56.2598121"}
----
Btw. You should be using the same Json options in the tested and testing code.
---- 
# Note on microseconds and `DateTimeKind` 
As you test more you may find mismatches on timestamps between the objects that your put into the db and their equivalents retrieved from the database. 
Depending on your setup `DateTime`s may be retrieved from the db as `Local` or `Unspecified` (even if you put Utc into the db) and you may loose some of the precision (the db column will store only what it's max resution is, it could be milliseconds). 
