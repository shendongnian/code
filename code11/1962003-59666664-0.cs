public class MyDisposable : IDisposable
{
    public void Dispose()
    {
        Console.WriteLine("Class implementation");
    }
    void IDisposable.Dispose()
    {
        Console.WriteLine("Explicit implementation");
    }
}
If you write `using (new MyDisposable()) { }`, then it will print "Explicit implementation".
That is, a `using` statement will call the actual implementation of `IDisposable.Dispose`. Calling `MyDisposable.Dispose()` will however print "Class implementation".
This is what the cast `((IDisposable)reader).Dispose()` is showing -- this equivalent C# code is calling the `Dispose` method which implements `IDisposable.Dispose()`.
---------
**However**, if the disposable object is a struct, then the C# code `((IDisposable)mystruct).Dispose()` will box it. A `using` statement will however *not* box structs.
Given:
public struct MyDisposableStruct : IDisposable
{
    public void Dispose()
    {
        Console.WriteLine("Class implementation");
    }
    void IDisposable.Dispose()
    {
        Console.WriteLine("Explicit implementation");
    }
}
It is not possible to write C# code to get it to print "Explicit implementation" without also boxing the struct. This however what a `using` statement does.
