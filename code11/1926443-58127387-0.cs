c#
A += 2; B += 2; C += 2;
But that's not really what you're asking for.
I will point out that, if you find this to be a common pattern in your code &mdash; common enough that you feel there ought to be a special syntax in the language to support it &mdash; you are probably overlooking an opportunity to define a new type, probably a `struct`, to represent the triplet values you're finding yourself adjusting uniformly on a regular basis.
For example, you might have something like this:
c#
struct MyStruct
{
    public int A { get; }
    public int B { get; }
    public int C { get; }
    public MyStruct(int a, int b, int c)
    {
        A = a;
        B = b;
        C = c;
    }
    public static MyStruct operator +(MyStruct v, int i)
    {
        return new MyStruct(v.A + i, v.B + i, v.C + i);
    }
}
which you could then use like this:
c#
MyStruct v = new MyStruct(1, 2, 3);
v += 2;
// v.A is now 3, v.B is now 4, v.C is now 5
