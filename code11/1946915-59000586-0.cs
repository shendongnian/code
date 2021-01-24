csharp
using System;
class Test
{
    static void Main()
    {
        var a = (5, 5);
        a.Item1 = 6;
        Console.WriteLine(a.Item1); // 6
        
        var t = a.GetType();
        var f = t.GetField("Item1");
        object obj = a;
        f.SetValue(obj, 10);
        a = ((int, int)) obj;
        Console.WriteLine(a.Item1); // 10
    }
}
