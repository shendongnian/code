 C#
using System;
[SomeAttribute("boop")]
static class P
{
    static void Main()
    {
        var obj = (SomeAttribute)Attribute.GetCustomAttribute(
            typeof(P), typeof(SomeAttribute));
        // note the attribute doesn't know the context
        // so we need to pass that *in*; an attribute
        // doesn't know what it has been attached to
        obj?.DoSomething(typeof(P));
    }
}
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct
    | AttributeTargets.Enum)]
class SomeAttribute : Attribute
{
    public string Name { get; }
    public SomeAttribute(string name)
        => Name = name;
    public void DoSomething(Type type)
        => Console.WriteLine($"hey {type.Name} - {Name}");
}
