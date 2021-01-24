public partial class MyClass
{
#if DEBUG
    public string SaySomething()
    {
        return "Something!";
    }
#endif 
}
For types which doesn't belong to you , you can use extension methods like this (You can also use this solution for the types which belongs to you):
public static class SqlCommandExtensions
{
#if DEBUG
    public static string SaySomething(this SqlCommand command)
    {
        return "Something!";
    }
#endif
}
