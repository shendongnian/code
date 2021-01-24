c#
namespace Test.Foo
{
    public partial class Bar
    {
        public string Hello => "World";
    }
}
namespace Test.Bar
{
    public partial class Bar
    {
        // This is impossible, as Test.Foo.Bar and Test.Bar.Bar are 2 entirely different classes
        public string World => Hello;
    }
}
[Here](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/partial-classes-and-methods) is the MSDN documentation on partial classes.  
P.S Why would you need something like this?
