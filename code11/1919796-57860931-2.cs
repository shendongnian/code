csharp
using System;
class Test
{
    static void Main()
    {
        object obj = ("foo", "bar");
        // Casting to the right type works... but a cast to
        // ValueTuple<object, object> would fail.
        var tuple = (ValueTuple<string, string>) obj;
        Console.WriteLine(tuple.Item1); // foo
        Console.WriteLine(tuple.Item2); // bar
    }
}
If you *want* a `ValueTuple<object, object>` you can do that, of course:
csharp
object myTuple = ((object) instance, new object());
If you want to refer to *any* value tuple, you may (depending on the framework you're targeting, unfortunately) be able to use [`ITuple`](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.ituple?view=netframework-4.8):
csharp
using System;
using System.Runtime.CompilerServices;
class Test
{
    static void Main()
    {
        object obj = ("foo", 10);
        var tuple = (ITuple) obj;
        
        for (int i = 0; i < tuple.Length; i++)
        {
            Console.WriteLine(tuple[i]); // foo then 10
        }
    }
}
