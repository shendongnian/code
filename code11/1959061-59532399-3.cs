var (x, y, z) = (1, 2, 3);
is morally equivalent to
var tuple = (1, 2, 3);
var x = tuple.Item1;
var y = tuple.Item2;
var z = tuple.Item3;
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
I don't know if it's documented anywhere, but credit to Jon Skeet who mentioned this in his C# in Depth (4th ed.).
Update:
Out of curiosity I checked if the optimisation applies in other places as well. It seems that it works as long as the left-hand-side variables are `ref` or `out` parameters. For example this:
csharp
public void Deconstruct(out int prop1, out object prop2, out string prop3) =>
    (prop1, prop2, prop3) = (_prop1, _prop2, _prop3);
generates code equivalent to this:
csharp
public void Deconstruct(out int prop1, out object prop2, out string prop3)
{
    int temp1 = _prop1;
    object temp2 = _prop2;
    string temp3 = _prop3;
    prop1 = temp1;
    prop2 = temp2;
    prop3 = temp3;
}
My educated guess is that since the IL differs between assignments to "normal" variables and to `ref` variables, the optimisation is simply not implemented for the second case, but I might be wrong.
