csharp
public static class Foo
{
    private static IFactory _factory = new NullFactory();
    public static void Init( IFactory factory ) => _factory = factory;
    public static string GetVersion() => _factory.GetVersion();
}
public interface IFactory
{
    string GetVersion();
}
public class NullFactory : IFactory
{
    public string GetVersion()
    {
        return string.Empty;
    }
}
If IFactory is not necessarily passed from outside, you can also consider static constructor.
csharp
public static class Foo
{
    private static IFactory _factory;
    static Foo()
    {
        _factory = new Factory();
    }
    public static string GetVersion() => _factory.GetVersion();
}
But after all I don't like to use static class except for extension method. I'd recommend to assign IFactory to whatever class need it.
