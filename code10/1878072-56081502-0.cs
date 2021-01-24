class Program
{
    static void Main(string[] args)
    {
        new Program().TestParameterized();
    }
    [TestCase]
    [Arguments(new object[] { 3, 0 })]
    [Arguments(new object[] { 1, 1 })]
    [Arguments(new object[] { 4, 4 })]
    public void TestParameterized(double x = 0, double y = 0, bool recursive = false)
    {
        Console.WriteLine($"{x} == {y}: {x == y}");
    }
}
[Serializable, AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
public class TestCaseAttribute : MethodInterceptionAspect
{
    private object[][] argumentsCollection;
    public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
    {
        var argumentAttributes = method.GetCustomAttributes(typeof(ArgumentsAttribute)).ToArray();
        argumentsCollection = new object[argumentAttributes.Length][];
        for (int i = 0; i < argumentAttributes.Length; i++)
        {
            object[] givenArguments = ((ArgumentsAttribute)argumentAttributes[i]).Arguments;
            object[] arguments = new object[givenArguments.Length + 1];
            Array.Copy(givenArguments, arguments, givenArguments.Length);
            arguments[givenArguments.Length] = true;
            argumentsCollection[i] = arguments;
        }
    }
    public override void OnInvoke(MethodInterceptionArgs args)
    {
        if ((bool)args.Arguments[args.Arguments.Count - 1])
        {
            args.Proceed();
            return;
        }
        foreach (var arguments in argumentsCollection)
        {
            args.Method.Invoke(args.Instance, arguments);
        }
    }
}
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
class ArgumentsAttribute : Attribute
{
    public object[] Arguments { get; }
    public ArgumentsAttribute(object[] arguments)
    {
        Arguments = arguments;
    }
}
