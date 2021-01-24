#nullable enable
public class C
{
    public int P1 { get; } 
}
public struct S
{
    public C? Member { get; } // Reluctantly mark as nullable reference because
                              // https://devblogs.microsoft.com/dotnet/nullable-reference-types-in-csharp/
                              // states:
                              // "Using the default constructor of a struct that has a
                              // field of nonnullable reference type. This one is 
                              // sneaky, since the default constructor (which zeroes 
                              // out the struct) can even be implicitly used in many
                              // places. Probably better not to warn, or else many
                              // existing struct types would be rendered useless."
}
public class Program
{
    public static void Main()
    {
        var instance = new S();
        Console.WriteLine(instance.Member.P1); // Warning
    }
}
