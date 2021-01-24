csharp
public static T Input<T>(string? display = default)
{
    if (!string.IsNullOrEmpty(display))
    {
        Console.WriteLine($"{display}: ");
    }
    return (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
}
csharp
var age = Input<int>("Age");
