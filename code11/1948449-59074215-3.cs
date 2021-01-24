public interface IMyException
{
    string MyProperty { get; }
}
Generic class implementing the interface:
public class MyException<T> : Exception, IMyException
{
    public string MyProperty { get; }
    public MyException(T prop)
    {
        MyProperty = prop?.ToString();
    }
}
Derived classes:
public class MyDerivedStringException : MyException<string>
{
    public MyDerivedStringException(string prop) : base(prop)
    {
    }
}
public class MyDerivedIntException : MyException<int>
{
    public MyDerivedIntException(int prop) : base(prop)
    {
    }
}
Usage:
try
{
    // ...
}
catch (Exception e) when (e is IMyException)
{
    // ...
}
The same can be done by creating a base class that inherits from `Exception` and than making `MyException<T>` derive from that base class.
