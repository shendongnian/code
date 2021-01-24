csharp
using System;
using System.Globalization;
struct Counter
{
    private int count;
    public int IncrementedCount => ++count;
}
class Test
{
    static readonly Counter readOnlyCounter;
    static Counter readWriteCounter;
    static void Main()
    {
        Console.WriteLine(readOnlyCounter.IncrementedCount);  // 1
        Console.WriteLine(readOnlyCounter.IncrementedCount);  // 1
        Console.WriteLine(readOnlyCounter.IncrementedCount);  // 1
        Console.WriteLine(readWriteCounter.IncrementedCount); // 1
        Console.WriteLine(readWriteCounter.IncrementedCount); // 2
        Console.WriteLine(readWriteCounter.IncrementedCount); // 3
    }
}
Here's the IL for a call to `readOnlyCounter.IncrementedCount`:
il
ldsfld     valuetype Counter Test::readOnlyCounter
stloc.0
ldloca.s   V_0
call       instance int32 Counter::get_IncrementedCount()
That copies the field value onto the stack, then calls the property... so the value of the field doesn't end up changing; it's incrementing `count` within the copy.
Compare that with the IL for the read-write field:
il
ldsflda    valuetype Counter Test::readWriteCounter
call       instance int32 Counter::get_IncrementedCount()
That makes the call directly on the field, so the field value ends up changing within the property.
Making a copy can be inefficient when the struct is large and the member *doesn't* mutate it. That's why in C# 7.2 and above, the `readonly` modifier can be applied to a struct. Here's another example:
csharp
using System;
using System.Globalization;
readonly struct ReadOnlyStruct
{
    public void NoOp() {}
}
class Test
{
    static readonly ReadOnlyStruct field1;
    static ReadOnlyStruct field2;
    static void Main()
    {
        field1.NoOp();
        field2.NoOp();
    }
}
With the `readonly` modifier on the struct itself, the `field1.NoOp()` call doesn't create a copy. If you remove the `readonly` modifier and recompile, you'll see that it creates a copy just like it did in `readOnlyCounter.IncrementedCount`.
I have a [blog post from 2014](https://codeblog.jonskeet.uk/2014/07/16/micro-optimization-the-surprising-inefficiency-of-readonly-fields/) that I wrote having found that `readonly` fields were causing performance issues in Noda Time. Fortunately that's now fixed using the `readonly` modifier on the structs instead.
