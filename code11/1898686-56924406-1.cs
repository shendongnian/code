c#
public class SomeProductionClass 
{
    public string findOccuranceMethod(string str) 
    {
        string occurString = "o";
        string replaceString = "MDDS";
        var array = str.Split(new[] { occurString }, StringSplitOptions.None);
        string result = string.Join(replaceString, array);
        return result;
    }
}
[TestMethod()]
public void findOccuranceMethodTest()
{
    // Arrange
    string expected = "The Haunting MDDSf Hill HMDDSuse!";
    var productionClass = new SomeProductionClass();
    // Act
    var result = productionClass.findOccuranceMethod("The Haunting of Hill House!");
    // Assert
    Assert.AreEqual(expected, result);
}
## How to test the original code
If for some reason you cannot control the production code, there are two options:
- replace `Console` with an abstraction
- reassign standard input/output to a custom stream: this is the least preferred option, as it makes setup/cleanup more complex, and can interfere with the test runner.
In either case, we must never modify the code under test in a way that would introduce separate branching for testing/production. E.g., "if running under test do A, otherwise do B" -- in such a case we aren't actually testing the production code but rather a different branch of it.
### Replace Console with an abstraction 
Here we introduce `IConsole` as a replacement for `System.Console`:
c#
public interface IConsole
{
    void WriteLine(string s);
    void ReadLine(); // void is enough for this example
}
// for use in production
public class RealConsole : IConsole
{
    public void WriteLine(string s)
    {
        Console.WriteLine(s); 
    }
    public void ReadLine()
    {
        Console.ReadLine();
    }
}
// for use in unit tests
public class TestConsole : IConsole
{
    public void WriteLine(string s)
    {
        Contents.Add(s);
    }
    public void ReadLine()
    {
    }
    public List<string> Contents { get; } = new List<string>();
}
The production code will remain as in the original post, except that now it consumes `_console` as a dependency:
c#
public class SomeProductionClass
{
    private readonly IConsole _console;
    public SomeProductionClass(IConsole console)
    {
        _console = console;
    }
    public void findOccuranceMethod()
    {
        string str = "The Haunting of Hill House!";
        _console.WriteLine("String: " + str);
        string occurString = "o";
        string replaceString = "MDDS";
        var array = str.Split(new[] { occurString }, StringSplitOptions.None);
        var count = array.Length - 1;
        string result = string.Join(replaceString, array);
        _console.WriteLine("String after replacing a character: " + result);
        _console.WriteLine("Number of replaces made: " + count);
        _console.ReadLine();
    }
}
and the test code would be:
c#
[TestMethod()]
public void findOccuranceMethodTest()
{
    // Arrange
    string expectedString = "The Haunting MDDSf Hill HMDDSuse!";
    int expectedCount = 2;
    var console = new TestConsole();
    var productionClass = new SomeProductionClass(console);
    // Act
    productionClass.findOccuranceMethod();
    // Assert
    Assert.AreEqual(3, console.Contents.Count);
    Assert.AreEqual("String: The Haunting of Hill House!", console.Contents[0]);
    Assert.AreEqual(
        $"String after replacing a character: {expectedString}", 
        console.Contents[1]);
    Assert.AreEqual(
        $"Number of replaces made: {expectedCount}", 
        console.Contents[2]);
}
