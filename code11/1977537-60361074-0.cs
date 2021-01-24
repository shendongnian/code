namespace LearningCSharp
{
    class Program
    {
        Program ProgramObject = new Program(); // The runtime will try to create an instance of this when the class is created (instantiated)... but since the class is creating an instance of itself, that instance will also try to create an instance and so on... this goes on forever until there isn't enough memory on the stack to allocate any more objects - a stack overflow.
        ... other code here
    }
}
A console application requires a static method that is called when the app starts:
static void Main(string[] args)
This static method cannot see instance members - so you will either need to make your `testing()` method static:
    static void Main(string[] args)
    {
        testing();
    }
    static void testing()
    {
        Console.WriteLine("Testing is Ok");
    }
or create another class that you can instantiate
namespace LearningCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            TestClass test = new TestClass();
            test.testing();
        }
    }
}
class TestClass 
{
    internal void testing()
    {
        Console.WriteLine("Testing is Ok");
    }
}
Note that the accessor for the `testing()` method should be `internal` or `public` or the `Main` class will not have access to it.
