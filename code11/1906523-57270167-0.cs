csharp
using System;
public static class Int32Extensions
{
    public static void Add(ref this int x, int y)
    {
        x = x + y;
    }
    
}
class Test
{
    static void Main()
    {
        int i = 9;
        i.Add(2);
        Console.WriteLine(i); // 11
    }
}
The `i.Add(2)` call is implicitly:
    Int32Extensions.Add(ref i, 2);
It will fail if you try to call it on something that isn't a variable.
But this will be really surprising behavior for many C# developers, as the `ref` is implicit. It also isn't valid for reference types.
   
