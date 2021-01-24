public interface IMyException
{
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
