using Xunit;
using Xunit.Abstractions;
public class MyTestClass
{
    private readonly ITestOutputHelper output;
    public MyTestClass(ITestOutputHelper output)
    {
        this.output = output;
    }
    [Fact]
    public void MyTest()
    {
        var temp = "my class!";
        output.WriteLine("This is output from {0}", temp);
    }
}
There's another method listed in the link I provided for writing to your Output window, but I prefer the previous.
