public static class MyStatic
{
    public static string SomeToolMethod()
    {
        return "Hello";
    }
}
public class MyStaticWrapper // or proxy, technically?
{
    public static string SomeToolMethod()
    {
        return MyStatic.SomeToolMethod();
    }
}
fooType.TypeInitializer.Invoke(new MyStaticWrapper()); /// untested, not sure of syntax here
