cs
#nullable enable
using System.Diagnostics.CodeAnalysis;
public sealed class MyOptions
{
    [DisallowNull]
    public string? Name { get; set; }
    
    public static void Test()
    {
        var options = new MyOptions();
        options.Name = null; // warning
        options.Name = "Hello"; // ok
    }
    
    public static void Test2()
    {
        var options = new MyOptions();
        options.Name.Substring(1); // warning on dereference
    }
}
