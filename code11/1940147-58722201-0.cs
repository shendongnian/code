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
