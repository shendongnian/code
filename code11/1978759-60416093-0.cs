csharp
public abstract class Foo
{
    protected Foo(string name) : this(name, 0)
    {
    }
    protected Foo(int value) : this("", value)
    {
    }
    private Foo(string name, int value)
    {
        // Do common things with name and value, maybe format them, etc
    }
}
The second use would be to make it so that the only possible derived classes would be *nested* classes, which have access to private members. I've used this before when I want to enforce a limited number of derived classes, with instances usually exposed via the base class
csharp
public abstract class Operation
{
    public static readonly Operation Add { get; } = new AddOperation();
    public static readonly Operation Subtract { get; } = new SubtractOperation();
    // Only nested classes can use this...
    private Operation()
    {
    }
    private class AddOperation : Operation
    {
        ...
    }
    private class SubtractOperation : Operation
    {
        ...
    }
}
