cs
[AttributeUsage(AttributeTargets.Method), AllowMultiple = true]
public class MyTestAttribute : TestAttribute, IWrapSetUpTearDown
{
    public TestCommand Wrap(TestCommand command)
    {
        return new MyTestCommand(command, command.Test.Arguments);
    }
}
cs
[TestCase(1)]
[TestCase(2)]
[MyTest]
public void MyTest(int foo)
{
//...
}
