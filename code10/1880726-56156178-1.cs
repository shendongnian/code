c#
using NUnit.Framework;
using TDDStack; // Add this
namespace NUnit.TDDStackTests
{
    [TestFixture]
    public class TestClass
    
    // etc ...
Or you can just prefix every usage of `MyStack` with the namespace that contains it:
    var stack = new TDDStack.MyStack();
If the classes are in separate projects, you will also need to add a reference to the project containing `MyStack` in the project where you want to use it (the unit test project). 
