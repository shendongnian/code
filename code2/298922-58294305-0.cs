using System;
using System.Text.Json;
public class MyDate
{
    public int year { get; set; }
    public int month { get; set; }
    public int day { get; set; }
}
public class Lad
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public MyDate DateOfBirth { get; set; }
}
class Program
{
    static void Main()
    {
        var lad = new Lad
        {
            FirstName = "Markoff",
            LastName = "Chaney",
            DateOfBirth = new MyDate
            {
                year = 1901,
                month = 4,
                day = 30
            }
        };
        var json = JsonSerializer.Serialize(lad);
        Console.WriteLine(json);
    }
}
In this example the classes to be serialized have properties rather than fields; the `System.Text.Json` serializer currently doesn't serialize fields.
Documentation:
* [System.Text.Json overview](https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-overview)
* [How to use System.Text.Json](https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to)
