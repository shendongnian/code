csharp
using System;
class Test
{
    static void Main()
    {
        object obj = ("foo", 10);
        var tuple = (ValueTuple<string, int>) obj;
        Console.WriteLine(tuple.Item1); // foo
        Console.WriteLine(tuple.Item2); // 10
    }
}
If you *want* a `ValueTuple<object, object>` you can do that, of course:
csharp
object myTuple = ((object) instance, new object());
