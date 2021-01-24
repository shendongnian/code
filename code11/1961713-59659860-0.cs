 c#
class SomethingAttribute : Attribute
{
    public SomethingAttribute(string name)
        => Name = name;
    public string Name { get; }
}
static class P
{
    public static void Foo([Something("Abc")] int x) {}
    static void Main()
    {
        var method = typeof(P).GetMethod(nameof(Foo));
        var p = method.GetParameters()[0];
        var attr = (SomethingAttribute)Attribute.GetCustomAttribute(
            p, typeof(SomethingAttribute));
        string name = attr?.Name;
        // you can now "ldstr {name}" etc
    }
}
The important point here is that the attribute isn't going to change at runtime - it is pure metadata; so, we can load it once with reflection when we are processing the model, then just emit the processed data, i.e. the line
 c#
// you can now "ldstr {name}" etc
