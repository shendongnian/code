var tuple = (1, 2, 3);
var x = tuple.Item1;
var y = tuple.Item2;
var z = tuple.Item3;
is morally equivalent to
var (x, y, z) = (1, 2, 3);
The left-hand-side can have any assignable variables, they can be locals, fields or get-only properties in a constructor. Using that is personal preference and code-style, I usually use them as in the MSDN docs - to write basic ctors in one line:
class C
{
    private int Prop1 { get; }
    private D Prop2 { get; }
    private string Prop3 { get; }
    public C(int prop1, D prop2, string prop3) =>
        (Prop1, Prop2, Prop3) = (prop1, prop2, prop3);
}
An interesting fact is that the Roslyn compiler recognises this pattern and avoids actually creating a tuple. If you throw this into a decompiler, you'll see the generated code is the same as for:
csharp
    public C(int prop1, D prop2, string prop3)
    {
        Prop1 = prop1;
        Prop2 = prop2;
        Prop3 = prop3;
    }
