public partial class MyClass
{
#if DEBUG
    public string SaySoemthing()
    {
        return "Something!";
    }
#endif 
}
Then the `SaySomething` method will be just available in debug mode.
In case you need if for types which doesn't belong to you, you can use something like this:
public static class SqlCommandExtensions
{
#if DEBUG
    public static string SaySoemthing(this SqlCommand command)
    {
        return "Something!";
    }
#endif
}
