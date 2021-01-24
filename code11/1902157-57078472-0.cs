csharp
public static class IDs
{
    private static string _someID; // backing field
    public static string SomeID
    {
        get
        {
            return _someID;
        }
        set
        {
            _someID = value;
            DoSomethingWithSomeID();
        }
    }
    private static DoSomethingWithSomeID()
    {
        // Use SomeID here.
        var someId = IDs.SomeID;
        switch (someId)
        {
            ...
        }
    }
}
public class OtherClass
{
    public void OtherMethod(string sym)
    {
        IDs.SomeID = sym;
    }
}
`DoSomethingWithSomeID` will be invoked every time someone sets a new value to `SomeID`.
  [1]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-constructors
  [2]: http://johnstejskal.com/wp/getters-setters-and-auto-properties-in-c-explained-get-set/
