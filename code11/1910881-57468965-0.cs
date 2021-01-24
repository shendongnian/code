csharp
public class Box<T> where T : struct
{
    public Box(T value) => Value = value;
    public T Value { get; }
}
But at the end you cause a lot of work for the user, which is done by the runtime in dotnet.
